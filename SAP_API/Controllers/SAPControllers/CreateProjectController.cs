using CreateProjectNS;
using DotnetSdkUtilities.Factory.ResponseFactory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.DTO.Request;
using SAP_API.Utilities;
using SAP_WSDL_Library.Connected_Services.CreateProjectNS;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SAP_API.Controllers.SAPControllers
{
    [Route("api/SAP/[controller]/[action]")]
    [ApiController]
    public class CreateProjectController : ControllerBase
    {
        private readonly ILogger<CreateProjectController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public CreateProjectController(ILogger<CreateProjectController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 專案(打銷售訂單也要打專案)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/CreateProject/Project
        ///     {
        ///        "Payload": {
        ///           "ZMaintainProjectAPI": {
        ///              "ProjectName": {
        ///                 "languageCode": "ZF",
        ///                 "Value": "BPM串接測試_2024042503"
        ///              },
        ///              "LanguageCode": "ZF",
        ///              "ProjectID": {
        ///                 "Value": "BPMTEST-2024042503"
        ///              },
        ///              "TypeCode": {
        ///                 "Value": "ZAIN"
        ///              },
        ///              "StartAndReleaseIndicator": true,
        ///              "StartAndReleaseIndicatorSpecified": true,
        ///              "CustomerID": {
        ///                 "Value": "C002"
        ///              },
        ///              "Task": [
        ///                 {
        ///                    "TaskID": "BPMTEST-2024042503",
        ///                    "TaskName": {
        ///                       "languageCode": "ZF",
        ///                       "Value": "BPM串接測試_2024042503"
        ///                    },
        ///                    "SummaryTaskIndicator": true,
        ///                    "SummaryTaskIndicatorSpecified": true,
        ///                    "ReleaseIndicator": true,
        ///                    "ReleaseIndicatorSpecified": true,
        ///                    "ResponsibleEmployeeID": {
        ///                       "Value": "E210902"
        ///                    },
        ///                    "TimeRecord": "2",
        ///                    "WorkDescription": "1",
        ///                    "ExpenseReportAllowed": "1",
        ///                    "StartDate": {
        ///                       "timeZoneCode": "UTC+8",
        ///                       "Value": "2024-04-25T08:00:00+08:00"
        ///                    },
        ///                    "FinishDate": {
        ///                       "timeZoneCode": "UTC+8",
        ///                       "Value": "2024-12-31T08:00:00+08:00"
        ///                    },
        ///                    "ResponsibleUnitID": "DD30",
        ///                    "Attachment": {
        ///                       "Document": [
        ///                          {
        ///                             "VisibleIndicator": true,
        ///                             "VisibleIndicatorSpecified": true,
        ///                             "CategoryCode": "3",
        ///                             "TypeCode": {
        ///                                "Value": "10001"
        ///                             },
        ///                             "Name": "BPM測試_專案",
        ///                             "Description": {
        ///                                "languageCode": "ZF",
        ///                                "Value": "BPMTEST_Project_備註,BPM已全部簽核完成"
        ///                             },
        ///                             "ExternalLinkWebURI": "https://www.ampower.com.tw/",
        ///                             "ActionCode": 0,
        ///                             "ActionCodeSpecified": true
        ///                          }
        ///                       ],
        ///                       "ActionCode": 0,
        ///                       "ActionCodeSpecified": true
        ///                    },
        ///                    "Material": [
        ///                       {
        ///                          "MaterialID": {
        ///                             "Value": "CAXL3C0001"
        ///                          },
        ///                          "FromStockIndicator": true,
        ///                          "FromStockIndicatorSpecified": true,
        ///                          "PlannedQuantity": {
        ///                             "unitCode": "M",
        ///                             "Value": 150
        ///                          }
        ///                       },
        ///                       {
        ///                          "MaterialID": {
        ///                             "Value": "LVPNMF0016"
        ///                          },
        ///                          "FromStockIndicator": true,
        ///                          "FromStockIndicatorSpecified": true,
        ///                          "PlannedQuantity": {
        ///                             "unitCode": "EA",
        ///                             "Value": 22
        ///                          }
        ///                       }
        ///                    ]
        ///                 },
        ///                 {
        ///                    "TaskID": "BPMTEST-2024042503-1",
        ///                    "TaskName": {
        ///                       "languageCode": "ZF",
        ///                       "Value": "BPM串接測試_2024042503-1"
        ///                    },
        ///                    "SummaryTaskIndicator": false,
        ///                    "SummaryTaskIndicatorSpecified": true,
        ///                    "ParentTaskID": "BPMTEST-2024042503",
        ///                    "ReleaseIndicator": true,
        ///                    "ReleaseIndicatorSpecified": true,
        ///                    "ResponsibleEmployeeID": {
        ///                       "Value": "E980501"
        ///                    },
        ///                    "TimeRecord": "2",
        ///                    "WorkDescription": "1",
        ///                    "ExpenseReportAllowed": "1",
        ///                    "StartDate": {
        ///                       "timeZoneCode": "UTC+8",
        ///                       "Value": "2024-04-25T08:00:00+08:00"
        ///                    },
        ///                    "FinishDate": {
        ///                       "timeZoneCode": "UTC+8",
        ///                       "Value": "2024-12-31T08:00:00+08:00"
        ///                    },
        ///                    "Material": [
        ///                       {
        ///                          "MaterialID": {
        ///                             "Value": "BATWLT0006"
        ///                          },
        ///                          "FromStockIndicator": true,
        ///                          "FromStockIndicatorSpecified": true,
        ///                          "PlannedQuantity": {
        ///                             "unitCode": "EA",
        ///                             "Value": 25
        ///                          }
        ///                       }
        ///                    ]
        ///                 },
        ///                 {
        ///                    "TaskID": "BPMTEST-2024042503-2",
        ///                    "TaskName": {
        ///                       "languageCode": "ZF",
        ///                       "Value": "BPM串接測試_2024042503-2"
        ///                    },
        ///                    "SummaryTaskIndicator": false,
        ///                    "SummaryTaskIndicatorSpecified": true,
        ///                    "ParentTaskID": "BPMTEST-2024042503",
        ///                    "ReleaseIndicator": true,
        ///                    "ReleaseIndicatorSpecified": true,
        ///                    "ResponsibleEmployeeID": {
        ///                       "Value": "E040601"
        ///                    },
        ///                    "TimeRecord": "2",
        ///                    "WorkDescription": "1",
        ///                    "ExpenseReportAllowed": "1",
        ///                    "StartDate": {
        ///                       "timeZoneCode": "UTC+8",
        ///                       "Value": "2024-04-25T08:00:00+08:00"
        ///                    },
        ///                    "FinishDate": {
        ///                       "timeZoneCode": "UTC+8",
        ///                       "Value": "2024-12-31T08:00:00+08:00"
        ///                    },
        ///                    "Material": [
        ///                       {
        ///                          "MaterialID": {
        ///                             "Value": "EXNE450007"
        ///                          },
        ///                          "FromStockIndicator": true,
        ///                          "FromStockIndicatorSpecified": true,
        ///                          "PlannedQuantity": {
        ///                             "unitCode": "LS",
        ///                             "Value": 17
        ///                          }
        ///                       }
        ///                    ]
        ///                 },
        ///                 {
        ///                    "TaskID": "BPMTEST-2024042503-2-1",
        ///                    "TaskName": {
        ///                       "languageCode": "ZF",
        ///                       "Value": "BPM串接測試_2024042502-2-1"
        ///                    },
        ///                    "SummaryTaskIndicator": false,
        ///                    "SummaryTaskIndicatorSpecified": true,
        ///                    "ParentTaskID": "BPMTEST-2024042502-2",
        ///                    "ReleaseIndicator": true,
        ///                    "ReleaseIndicatorSpecified": true,
        ///                    "ResponsibleEmployeeID": {
        ///                       "Value": "E040601"
        ///                    },
        ///                    "TimeRecord": "2",
        ///                    "WorkDescription": "1",
        ///                    "ExpenseReportAllowed": "1",
        ///                    "StartDate": {
        ///                       "timeZoneCode": "UTC+8",
        ///                       "Value": "2024-04-25T08:00:00+08:00"
        ///                    },
        ///                    "FinishDate": {
        ///                       "timeZoneCode": "UTC+8",
        ///                       "Value": "2024-12-31T08:00:00+08:00"
        ///                    }
        ///                 }
        ///              ],
        ///              "TeamMember": [
        ///                 {
        ///                    "EmployeeID": {
        ///                       "Value": "E040601"
        ///                    }
        ///                 },
        ///                 {
        ///                    "EmployeeID": {
        ///                       "Value": "E980501"
        ///                    }
        ///                 },
        ///                 {
        ///                    "EmployeeID": {
        ///                       "Value": "E210902"
        ///                    }
        ///                 },
        ///                 {
        ///                    "EmployeeID": {
        ///                       "Value": "E020301"
        ///                    }
        ///                 }
        ///              ]
        ///           }
        ///        },
        ///        "User": "QQ"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<ZMaintainProjectAPICreateConfirmation>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Project([FromBody] ProjectRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.CreateProject);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new YGQJ2RDPY_CustomMaintainProjectClient(binding, endpointAddress);

            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.CreateAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.ZMaintainProjectAPICreateConfirmation_sync?.ZMaintainProjectAPI == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.ZMaintainProjectAPICreateConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.ZMaintainProjectAPICreateConfirmation_sync.ZMaintainProjectAPI);
            }
        }
    }
}
