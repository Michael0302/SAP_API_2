using DotnetSdkUtilities.Factory.ResponseFactory;
using InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInNS;
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
    public class InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController : ControllerBase
    {
        private readonly ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController(ILogger<InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 內部後勤-專案耗用
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationIn/InternalLogisticsProjectConsumption
        ///     {
        ///        "Payload": [
        ///           {
        ///              "ExternalID": {
        ///                 "Value": "PJ001-0527"
        ///              },
        ///              "SiteID": {
        ///                 "Value": "AT"
        ///              },
        ///              "TransactionDateTime": "2024-05-26T15:35:19.457648+08:00",
        ///              "TransactionDateTimeSpecified": true,
        ///              "InventoryMovementDirectionCode": "1",
        ///              "ProjectTaskKey": {
        ///                 "TaskID": {
        ///                    "Value": "AIN21051-Z12"
        ///                 }
        ///              },
        ///              "InventoryChangeItemGoodsConsumptionInformationForProject": [
        ///                 {
        ///                    "ExternalItemID": "PJ001-10",
        ///                    "MaterialInternalID": {
        ///                       "Value": "EPKLEC0034"
        ///                    },
        ///                    "OwnerPartyInternalID": {
        ///                       "Value": "AT"
        ///                    },
        ///                    "InventoryRestrictedUseIndicator": false,
        ///                    "LogisticsAreaID": "CS02",
        ///                    "InventoryItemChangeQuantity": {
        ///                       "Quantity": {
        ///                          "unitCode": "EA",
        ///                          "Value": 1
        ///                       },
        ///                       "QuantityTypeCode": {
        ///                          "Value": "EA"
        ///                       }
        ///                    },
        ///                    "AccountingCodingBlock": {
        ///                       "AccountingCodingBlockTypeCode": {
        ///                          "Value": "PRO"
        ///                       },
        ///                       "ProjectReference": {
        ///                          "ProjectID": {
        ///                             "Value": "AIN21051"
        ///                          }
        ///                       },
        ///                       "SalesOrderReference": {
        ///                          "ID": {
        ///                             "Value": "538"
        ///                          },
        ///                          "ItemID": "10"
        ///                       }
        ///                    }
        ///                 }
        ///              ]
        ///           }
        ///        ],
        ///        "User": "Andy"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<GACDetails[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> InternalLogisticsProjectConsumption([FromBody] InternalLogisticsProjectConsumptionRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationInClient(binding, endpointAddress);
            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.DoGoodsConsumptionForProjectAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.GoodsAndActivityConfirmationGoodsConsumptionForProjectResponse?.GACDetails == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.GoodsAndActivityConfirmationGoodsConsumptionForProjectResponse?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.GoodsAndActivityConfirmationGoodsConsumptionForProjectResponse.GACDetails);
            }
        }
    }
}
