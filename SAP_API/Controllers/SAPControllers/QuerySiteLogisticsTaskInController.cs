using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QuerySiteLogisticsTaskInNS;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.DTO.Request;
using SAP_API.DTO.Response;
using SAP_API.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SAP_API.Controllers.SAPControllers
{
    [Route("api/SAP/[controller]/[action]")]
    [ApiController]
    public class QuerySiteLogisticsTaskInController : ControllerBase
    {
        private readonly ILogger<QuerySiteLogisticsTaskInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public QuerySiteLogisticsTaskInController(ILogger<QuerySiteLogisticsTaskInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 查詢倉庫工作細項(僅更換採購單單號)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/QuerySiteLogisticsTaskIn/GetWarehouseTaskDetails
        ///     {
        ///        "Payload": {
        ///           "SiteLogisticsTaskSelectionByElements": {
        ///              "SelectionByReferenceDocumentID": [
        ///                 {
        ///                    "InclusionExclusionCode": "I",
        ///                    "IntervalBoundaryTypeCode": "1",
        ///                    "LowerBoundaryReferenceDocumentID": {
        ///                       "Value": "2911"
        ///                    },
        ///                    "UpperBoundaryReferenceDocumentID": {
        ///                       "Value": ""
        ///                    }
        ///                 }
        ///              ]
        ///           },
        ///           "ProcessingConditions": {
        ///              "QueryHitsMaximumNumberValue": 10,
        ///              "QueryHitsMaximumNumberValueSpecified": true,
        ///              "QueryHitsUnlimitedIndicator": false,
        ///              "LastReturnedObjectID": {
        ///                 "Value": ""
        ///              }
        ///           }
        ///        },
        ///        "User": "April"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<GetWarehouseTaskDetailsResponse>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> GetWarehouseTaskDetails([FromBody] GetWarehouseTaskDetailsRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.QuerySiteLogisticsTaskIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new QuerySiteLogisticsTaskInClient(binding, endpointAddress);

            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.FindByElementsAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.SiteLogistcsTaskByElementsResponse_sync?.ProcessingConditions == null && response.SiteLogistcsTaskByElementsResponse_sync?.SiteLogisticsTask == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.SiteLogistcsTaskByElementsResponse_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(new GetWarehouseTaskDetailsResponse()
                {
                    ProcessingConditions = response.SiteLogistcsTaskByElementsResponse_sync.ProcessingConditions,
                    SiteLogisticsTask = response.SiteLogistcsTaskByElementsResponse_sync.SiteLogisticsTask,
                });
            }
        }
    }
}
