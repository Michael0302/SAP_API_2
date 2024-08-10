using CreateProjectPurchaseRequestNS;
using DotnetSdkUtilities.Factory.ResponseFactory;
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
    public class CreateProjectPurchaseRequestController : ControllerBase
    {
        private readonly ILogger<CreateProjectPurchaseRequestController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public CreateProjectPurchaseRequestController(ILogger<CreateProjectPurchaseRequestController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 採購請求-專案第三方
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/CreateProjectPurchaseRequest/ProjectThirdPartyPurchaseRequest
        ///     {
        ///        "Payload": {
        ///           "ZProjectPurchaseRequestAPI": {
        ///              "TypeCode": "1",
        ///              "ProjectID": {
        ///                 "Value": "BPMTEST-2024042503"
        ///              },
        ///              "TextCollection": {
        ///                 "Text": [
        ///                    {
        ///                       "TypeCode": {
        ///                          "Value": "10011"
        ///                       },
        ///                       "LanguageCode": "ZF",
        ///                       "TextContent": {
        ///                          "Text": {
        ///                             "languageCode": "ZF",
        ///                             "Value": "BPM串接_專案採購請求_240514-01"
        ///                          },
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       },
        ///                       "ActionCode": 0,
        ///                       "ActionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "ActionCode": 0,
        ///                 "ActionCodeSpecified": true
        ///              },
        ///              "Attachment": {
        ///                 "Document": [
        ///                    {
        ///                       "VisibleIndicator": true,
        ///                       "VisibleIndicatorSpecified": true,
        ///                       "CategoryCode": "3",
        ///                       "TypeCode": {
        ///                          "Value": "10001"
        ///                       },
        ///                       "Name": "BPM串接_專案採購請求_240514-01",
        ///                       "AlternativeName": "Document Title_BPM串接_專案採購請求",
        ///                       "Description": {
        ///                          "languageCode": "ZF",
        ///                          "Value": "BPM串接_專案採購請求_240514-01"
        ///                       },
        ///                       "ExternalLinkWebURI": "https://www.ampower.com.tw/",
        ///                       "ActionCode": 0,
        ///                       "ActionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "ActionCode": 0,
        ///                 "ActionCodeSpecified": true
        ///              },
        ///              "Item": [
        ///                 {
        ///                    "ProjectNo": "案件編號_BPM_24051401",
        ///                    "Specnote": "",
        ///                    "Material_Spec": "",
        ///                    "RequestedQuantity": {
        ///                       "unitCode": "LS",
        ///                       "Value": 3
        ///                    },
        ///                    "TypeCode": "18",
        ///                    "DeliveryPeriod": {
        ///                       "StartDateTime": {
        ///                          "timeZoneCode": "UTC+8",
        ///                          "Value": "2024-05-15T08:00:00+08:00"
        ///                       },
        ///                       "EndDateTime": {
        ///                          "timeZoneCode": "UTC+8",
        ///                          "Value": "2024-05-18T08:00:00+08:00"
        ///                       }
        ///                    },
        ///                    "ProductID": {
        ///                       "Value": "EXNE450007"
        ///                    },
        ///                    "ProjectTaskID": {
        ///                       "Value": "BPMTEST-2024042503-2"
        ///                    },
        ///                    "Price": {
        ///                       "currencyCode": "TWD",
        ///                       "Value": 1111
        ///                    },
        ///                    "SupplierID": "B02009",
        ///                    "ShipToLocationID": {
        ///                       "Value": ""
        ///                    },
        ///                    "TextCollection": {
        ///                       "Text": [
        ///                          {
        ///                             "TypeCode": {
        ///                                "Value": "10011"
        ///                             },
        ///                             "LanguageCode": "ZF",
        ///                             "TextContent": {
        ///                                "Text": {
        ///                                   "languageCode": "ZF",
        ///                                   "Value": "BPM串接_專案採購請求表身_240514-01"
        ///                                }
        ///                             },
        ///                             "ActionCode": 0,
        ///                             "ActionCodeSpecified": true
        ///                          }
        ///                       ],
        ///                       "ActionCode": 0,
        ///                       "ActionCodeSpecified": true
        ///                    },
        ///                    "Attachment": {
        ///                       "Document": [
        ///                          {
        ///                             "VisibleIndicator": true,
        ///                             "VisibleIndicatorSpecified": true,
        ///                             "CategoryCode": "3",
        ///                             "TypeCode": {
        ///                                "Value": "10001"
        ///                             },
        ///                             "Name": "BPM串接_專案採購請求表身_240514-01",
        ///                             "AlternativeName": "Document Title_BPM串接_專案採購請求表身",
        ///                             "Description": {
        ///                                "languageCode": "ZF",
        ///                                "Value": "BPM串接_專案採購請求表身_240514-01"
        ///                             },
        ///                             "ExternalLinkWebURI": "https://www.ampower.com.tw/",
        ///                             "ActionCode": 0,
        ///                             "ActionCodeSpecified": true
        ///                          }
        ///                       ],
        ///                       "ActionCode": 0,
        ///                       "ActionCodeSpecified": true
        ///                    }
        ///                 }
        ///              ]
        ///           }
        ///        },
        ///        "User": "Jake"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<ZProjectPurchaseRequestAPICreateConfirmation>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> ProjectThirdPartyPurchaseRequest([FromBody] ProjectThirdPartyPurchaseRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.CreateProjectPurchaseRequest);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new YGQJ2RDPY_CustomCreateProjectPurchaseRequestClient(binding, endpointAddress);

            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.CreateAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.ZProjectPurchaseRequestAPICreateConfirmation_sync?.ZProjectPurchaseRequestAPI == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.ZProjectPurchaseRequestAPICreateConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.ZProjectPurchaseRequestAPICreateConfirmation_sync.ZProjectPurchaseRequestAPI);
            }
        }
    }
}
