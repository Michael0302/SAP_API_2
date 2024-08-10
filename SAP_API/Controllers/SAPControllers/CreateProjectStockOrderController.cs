using DotnetSdkUtilities.Factory.ResponseFactory;
using InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.DTO.Request;
using SAP_API.Utilities;
using System.ServiceModel.Channels;
using System.ServiceModel;
using CreateProjectStockOrderNS;

namespace SAP_API.Controllers.SAPControllers
{

    [Route("api/SAP/[controller]/[action]")]
    [ApiController]
    public class CreateProjectStockOrderController : ControllerBase
    {
        private readonly ILogger<CreateProjectStockOrderController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public CreateProjectStockOrderController(ILogger<CreateProjectStockOrderController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 客服領料
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/CreateProjectStockOrder/ProjectStockOrder
        ///     {
        ///        "Payload": {
        ///            "ZProjectStockOrderAPI": {
        ///                 "ProjectID": {
        ///                     "Value": "BPMTEST-2024042503"
        ///                 },
        ///                 "Item": [
        ///                     {
        ///                         "ProjectTaskID": {
        ///                             "Value": "BPMTEST-2024042503"
        ///                         },
        ///                         "TypeCode": "PRDL",
        ///                         "RequestedQuantity": {
        ///                             "Value": "12"
        ///                         },
        ///                         "Recipient": {
        ///                             "Value": "C002"
        ///                         },
        ///                         "MateriaID": {
        ///                             "Value": "LVPNMF0016"
        ///                         },
        ///                         "DeliveryDate": {
        ///                             "Value": "2024-05-26T15:35:19.457648+08:00"
        ///                         }
        ///                     }
        ///                 ]
        ///            }
        ///        },
        ///        "User": "string"
        ///     }
        /// </remarks>

        [ProducesResponseType(typeof(ApiOkResponse<GACDetails[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> ProjectStockOrder([FromBody] ProjectStockOrderRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.CreateProjectStockOrder);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new YGQJ2RDPY_CustomCreateProjectStockOrderClient(binding, endpointAddress);

            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.CreateAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.ZProjectStockOrderAPICreateConfirmation_sync?.ZProjectStockOrderAPI == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.ZProjectStockOrderAPICreateConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.ZProjectStockOrderAPICreateConfirmation_sync.ZProjectStockOrderAPI);
            }
        }
    }
}
