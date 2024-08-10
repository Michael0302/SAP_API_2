using DotnetSdkUtilities.Factory.ResponseFactory;
using InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.DTO.Request;
using SAP_API.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SAP_API.Controllers.SAPControllers
{
    [Route("api/SAP/[controller]/[action]")]
    [ApiController]
    public class InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController : ControllerBase
    {
        private readonly ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController(ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 內部後勤-物料異動
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/InventoryProcessingGoodsAndActivityConfirmationGoodsMovementIn/InternalLogisticsMaterialMovement
        ///     {
        ///        "Payload": [
        ///           {
        ///              "ExternalID": {
        ///                 "Value": "FANG_BPMTEST_01"
        ///              },
        ///              "SiteID": {
        ///                 "Value": "AT"
        ///              },
        ///              "TransactionDateTime": "2024-05-26T06:35:19+08:00",
        ///              "TransactionDateTimeSpecified": true,
        ///              "InventoryChangeItemGoodsMovement": [
        ///                 {
        ///                    "ExternalItemID": "XXXXX-10",
        ///                    "MaterialInternalID": {
        ///                       "Value": "EPKLEC0034"
        ///                    },
        ///                    "OwnerPartyInternalID": {
        ///                       "Value": "AT"
        ///                    },
        ///                    "InventoryRestrictedUseIndicator": false,
        ///                    "SourceLogisticsAreaID": "CS01",
        ///                    "TargetLogisticsAreaID": "CS02",
        ///                    "InventoryItemChangeQuantity": {
        ///                       "Quantity": {
        ///                          "unitCode": "EA",
        ///                          "Value": 3
        ///                       },
        ///                       "QuantityTypeCode": {
        ///                          "Value": "EA"
        ///                       }
        ///                    }
        ///                 }
        ///              ]
        ///           }
        ///        ],
        ///        "User": "Allen"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<GACDetails[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> InternalLogisticsMaterialMovement([FromBody] InternalLogisticsMaterialMovementRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.InventoryProcessingGoodsAndActivityConfirmationGoodsMovementIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInClient(binding, endpointAddress);

            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.DoGoodsMovementGoodsAndActivityConfirmationAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.GoodsAndActivityConfoirmationGoodsMovementResponse?.GACDetails == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.GoodsAndActivityConfoirmationGoodsMovementResponse?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.GoodsAndActivityConfoirmationGoodsMovementResponse.GACDetails);
            }
        }
    }
}
