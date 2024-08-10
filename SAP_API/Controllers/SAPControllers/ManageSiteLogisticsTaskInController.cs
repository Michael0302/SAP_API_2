using DotnetSdkUtilities.Factory.ResponseFactory;
using ManageSiteLogisticsTaskInNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.DTO.Request;
using SAP_API.DTO.Response;
using SAP_API.Utilities;
using SAP_WSDL_Library.Connected_Services.ManageSiteLogisticsTaskInNS;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SAP_API.Controllers.SAPControllers
{
    [Route("api/SAP/[controller]/[action]")]
    [ApiController]
    public class ManageSiteLogisticsTaskInController : ControllerBase
    {
        private readonly ILogger<ManageSiteLogisticsTaskInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public ManageSiteLogisticsTaskInController(ILogger<ManageSiteLogisticsTaskInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 進項交貨(要先打QuerySiteLogisticsTaskIn)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/ManageSiteLogisticsTaskIn/ProcessIncomingDelivery
        ///     {
        ///       "Payload": {
        ///          "BasicMessageHeader": {
        ///             "ID": {
        ///                "Value": "1"
        ///             }
        ///          },
        ///          "SiteLogisticsTask": [
        ///             {
        ///                "SiteLogisticTaskID": {
        ///                   "Value": "21"
        ///                },
        ///                "SiteLogisticTaskUUID": {
        ///                   "Value": "171d133d-f7be-1eef-80d7-21cdf62bf3ef"
        ///                },
        ///                "ActualExecutionOn": "2024-04-25T18:33:00.1234567+08:00",
        ///                "ActualExecutionOnSpecified": true,
        ///                "ReferenceObject": [
        ///                   {
        ///                      "ReferenceObjectUUID": {
        ///                         "Value": "171d133d-f7be-1eef-80d7-21cdf62c13ef"
        ///                      },
        ///                      "OperationActivity": [
        ///                         {
        ///                            "OperationActivityUUID": {
        ///                               "Value": "171d133d-f7be-1eef-80d7-21cdf62ad3ef"
        ///                            },
        ///                            "MaterialOutput": [
        ///                               {
        ///                                  "MaterialOutputUUID": {
        ///                                     "Value": "171d133d-f7be-1eef-80d7-21cdf62b33ef"
        ///                                  },
        ///                                  "ProductID": {
        ///                                     "Value": "PECNMT0017"
        ///                                  },
        ///                                  "SourceLogisticsAreaIDPostSplit": "",
        ///                                  "TargetLogisticsAreaID": "CS01",
        ///                                  "ActualQuantity": {
        ///                                     "unitCode": "EA",
        ///                                     "Value": 2
        ///                                  }
        ///                               }
        ///                            ]
        ///                         }
        ///                      ]
        ///                   }
        ///                ]
        ///             }
        ///          ]
        ///       },
        ///       "User": "Queen"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<SiteLogisticsTaskBundleMaintainResponse[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> ProcessIncomingDelivery([FromBody] ProcessIncomingDeliveryRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManageSiteLogisticsTaskIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManageSiteLogisticsTaskInClient(binding, endpointAddress);

            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.MaintainBundle_V1Async(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.SiteLogisticsTaskBundleMaintainResponse_sync_V1?.SiteLogisticsTaskResponse == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.SiteLogisticsTaskBundleMaintainResponse_sync_V1?.ExceptionMessage.Select(x => x.MessageNote)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.SiteLogisticsTaskBundleMaintainResponse_sync_V1.SiteLogisticsTaskResponse);
            }
        }
    }
}
