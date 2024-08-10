using DotnetSdkUtilities.Factory.ResponseFactory;
using ManageSalesOrderInNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using QuerySalesOrderInNS;
using SAP_API.Common;
using SAP_API.Configuration;
using SAP_API.DTO.Request;
using SAP_API.Utilities;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml.Serialization;

namespace SAP_API.Controllers.SAPControllers
{
    [Route("api/SAP/[controller]/[action]")]
    [ApiController]
    public class ManageSalesOrderInController : ControllerBase
    {
        private readonly ILogger<ManageSalesOrderInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public ManageSalesOrderInController(ILogger<ManageSalesOrderInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 銷售訂單-物料
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/ManageSalesOrderIn/MaterialSalesOrder
        ///     {
        ///        "Payload": {
        ///           "SalesOrder": [
        ///              {
        ///                 "ObjectNodeSenderTechnicalID": "S1",
        ///                 "BuyerID": {
        ///                    "Value": "ACS112162"
        ///                 },
        ///                 "PostingDate": "2024-03-30T18:58:00+08:00",
        ///                 "PostingDateSpecified": true,
        ///                 "Name": {
        ///                    "languageCode": "ZF",
        ///                    "Value": "ACS112162 洲美機電-台大癌醫及質子中心高低壓測試支援"
        ///                 },
        ///                 "SO_TYPE": "121",
        ///                 "DataOriginTypeCode": "5",
        ///                 "ReleaseAllItemsToExecution": true,
        ///                 "ReleaseAllItemsToExecutionSpecified": true,
        ///                 "FinishFulfilmentProcessingOfAllItems": true,
        ///                 "FinishFulfilmentProcessingOfAllItemsSpecified": true,
        ///                 "AccountParty": {
        ///                    "PartyID": {
        ///                       "Value": "D178"
        ///                    },
        ///                    "actionCode": 3,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "EmployeeResponsibleParty": {
        ///                    "PartyID": {
        ///                       "Value": "8000000169"
        ///                    }
        ///                 },
        ///                 "SalesUnitParty": {
        ///                    "PartyID": {
        ///                       "Value": "CS20"
        ///                    },
        ///                    "actionCode": 3,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "PricingTerms": {
        ///                    "CurrencyCode": "TWD",
        ///                    "PriceDateTime": {
        ///                       "timeZoneCode": "UTC+8",
        ///                       "Value": "2024-03-30T18:58:00+08:00"
        ///                    },
        ///                    "GrossAmountIndicator": false,
        ///                    "actionCode": 3,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "Item": [
        ///                    {
        ///                       "ID": "10",
        ///                       "ProcessingTypeCode": "TAN",
        ///                       "ItemProduct": {
        ///                          "ProductInternalID": {
        ///                             "Value": "BWBBPU0024"
        ///                          },
        ///                          "actionCode": 3,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "ItemScheduleLine": [
        ///                          {
        ///                             "ID": "1",
        ///                             "TypeCode": "1",
        ///                             "Quantity": {
        ///                                "unitCode": "EA",
        ///                                "Value": 1
        ///                             },
        ///                             "actionCode": 3,
        ///                             "actionCodeSpecified": true
        ///                          }
        ///                       ],
        ///                       "PriceAndTaxCalculationItem": {
        ///                          "ItemMainPrice": {
        ///                             "Rate": {
        ///                                "DecimalValue": 17776,
        ///                                "CurrencyCode": "TWD",
        ///                                "BaseDecimalValue": 1,
        ///                                "BaseMeasureUnitCode": "EA"
        ///                             },
        ///                             "actionCode": 3,
        ///                             "actionCodeSpecified": true
        ///                          },
        ///                          "ItemPriceComponent": [
        ///                             {
        ///                                "TypeCode": {
        ///                                   "listID": "2",
        ///                                   "Value": "0009"
        ///                                },
        ///                                "Description": {
        ///                                   "languageCode": "EN",
        ///                                   "Value": "Cost Estimate"
        ///                                },
        ///                                "Rate": {
        ///                                   "DecimalValue": 31300,
        ///                                   "CurrencyCode": "TWD",
        ///                                   "BaseDecimalValue": 1,
        ///                                   "BaseMeasureUnitCode": "LS"
        ///                                },
        ///                                "RateBaseQuantityTypeCode": {
        ///                                   "Value": "LS"
        ///                                },
        ///                                "actionCode": 3,
        ///                                "actionCodeSpecified": true
        ///                             }
        ///                          ],
        ///                          "actionCode": 3,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "actionCode": 3,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true
        ///              }
        ///           ]
        ///        },
        ///        "User": "string"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<SalesOrderMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> MaterialSalesOrder([FromBody] MaterialSalesOrderRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManageSalesOrderIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManageSalesOrderInClient(binding, endpointAddress);
            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.MaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.SalesOrderBundleMaintainConfirmation_sync?.SalesOrder == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.SalesOrderBundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.SalesOrderBundleMaintainConfirmation_sync.SalesOrder);
            }
        }
        /// <summary>
        /// 銷售訂單-專案 (含修改成本估算金額)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/ManageSalesOrderIn/ProjectSalesOrder
        ///     {
        ///        "Payload": {
        ///           "SalesOrder": [
        ///              {
        ///                 "BuyerID": {
        ///                    "Value": "ACS112162_BPM050603"
        ///                 },
        ///                 "Name": {
        ///                    "languageCode": "ZF",
        ///                    "Value": "ACS112162_BPM串接測試"
        ///                 },
        ///                 "SO_TYPE": "121",
        ///                 "DataOriginTypeCode": "5",
        ///                 "AccountParty": {
        ///                    "PartyID": {
        ///                       "Value": "D178"
        ///                    },
        ///                    "actionCode": 3,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "EmployeeResponsibleParty": {
        ///                    "PartyID": {
        ///                       "Value": "E999966"
        ///                    }
        ///                 },
        ///                 "SalesUnitParty": {
        ///                    "PartyID": {
        ///                       "Value": "CS20"
        ///                    },
        ///                    "actionCode": 3,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "PricingTerms": {
        ///                    "CurrencyCode": "TWD",
        ///                    "GrossAmountIndicator": false,
        ///                    "actionCode": 3,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "Item": [
        ///                    {
        ///                       "ID": "10",
        ///                       "ProcessingTypeCode": "TPFP",
        ///                       "ItemProduct": {
        ///                          "ProductInternalID": {
        ///                             "Value": "RMPJPJ0001"
        ///                          },
        ///                          "actionCode": 3,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "ItemServiceTerms": {
        ///                          "ProjectTaskID": {
        ///                             "Value": "ACS112162"
        ///                          }
        ///                       },
        ///                       "ItemScheduleLine": [
        ///                          {
        ///                             "ID": "1",
        ///                             "TypeCode": "1",
        ///                             "Quantity": {
        ///                                "unitCode": "LS",
        ///                                "Value": 1
        ///                             },
        ///                             "actionCode": 3,
        ///                             "actionCodeSpecified": true
        ///                          }
        ///                       ],
        ///                       "PriceAndTaxCalculationItem": {
        ///                          "TaxationCharacteristicsCode": {
        ///                             "listID": "TW",
        ///                             "Value": "S351"
        ///                          },
        ///                          "ItemMainPrice": {
        ///                             "Rate": {
        ///                                "DecimalValue": 77300,
        ///                                "CurrencyCode": "TWD",
        ///                                "BaseDecimalValue": 1,
        ///                                "BaseMeasureUnitCode": "LS"
        ///                             },
        ///                             "actionCode": 3,
        ///                             "actionCodeSpecified": true
        ///                          },
        ///                          "ItemPriceComponent": [
        ///                             {
        ///                                "TypeCode": {
        ///                                   "listID": "2",
        ///                                   "Value": "0009"
        ///                                },
        ///                                "Description": {
        ///                                   "languageCode": "EN",
        ///                                   "Value": "Cost Estimate"
        ///                                },
        ///                                "Rate": {
        ///                                   "DecimalValue": 31300,
        ///                                   "CurrencyCode": "TWD",
        ///                                   "BaseDecimalValue": 1,
        ///                                   "BaseMeasureUnitCode": "LS"
        ///                                },
        ///                                "RateBaseQuantityTypeCode": {
        ///                                   "Value": "LS"
        ///                                },
        ///                                "actionCode": 3,
        ///                                "actionCodeSpecified": true
        ///                             }
        ///                          ],
        ///                          "actionCode": 3,
        ///                          "actionCodeSpecified": true
        ///                       }
        ///                    }
        ///                 ],
        ///                 "CashDiscountTerms": {
        ///                    "Code": {
        ///                       "Value": "Z310"
        ///                    },
        ///                    "actionCode": 3,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true
        ///              }
        ///           ]
        ///        },
        ///        "User": "Peter"
        ///     }
        ///     POST /api/SAP/ManageSalesOrderIn/ProjectSalesOrder
        ///     {
        ///        "Payload": {
        ///           "SalesOrder": [
        ///              {
        ///                 "ID": {
        ///                    "Value": "2464"
        ///                 },
        ///                 "Item": [
        ///                    {
        ///                       "ID": "10",
        ///                       "PriceAndTaxCalculationItem": {
        ///                          "ItemPriceComponent": [
        ///                             {
        ///                                "UUID": {
        ///                                   "Value": "1b2377a5-1e36-1eef-82ee-a9218248be5a"
        ///                                },
        ///                                "Rate": {
        ///                                   "DecimalValue": 31125,
        ///                                   "BaseDecimalValue": 1
        ///                                },
        ///                                "actionCode": 1,
        ///                                "actionCodeSpecified": true
        ///                             }
        ///                          ],
        ///                          "actionCode": 1,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "actionCode": 3,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "actionCode": 3,
        ///                 "actionCodeSpecified": true
        ///              }
        ///           ]
        ///        },
        ///        "User": "Daniel"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<SalesOrderMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> ProjectSalesOrder([FromBody] ProjectSalesOrderRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            // 先查詢明細
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.QuerySalesOrderIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var queryClient = new QuerySalesOrderInClient(binding, endpointAddress);

            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            if (request.Payload.SalesOrder.FirstOrDefault().actionCode == ActionCode.Item04)
            {
                queryClient.ClientCredentials.UserName.UserName = userName;
                queryClient.ClientCredentials.UserName.Password = password;

                // 只會有一筆，取第一筆就好
                var saleOrderId = request.Payload.SalesOrder.Select(x => x.ID.Value)?.FirstOrDefault();
                #region 查詢明細request
                var queryPayload = new SalesOrderByElementsQueryMessage_sync()
                {
                    SalesOrderSelectionByElements = new SalesOrderByElementsQuerySelectionByElements()
                    {
                        SelectionByID = [ new SalesOrderByElementsQuerySelectionByID()
                        {
                            InclusionExclusionCode = "I",
                            IntervalBoundaryTypeCode = "1",
                            LowerBoundaryID = new QuerySalesOrderInNS.BusinessTransactionDocumentID()
                            {
                                Value = saleOrderId
                            }

                        }]
                    },
                    ProcessingConditions = new QueryProcessingConditions()
                    {
                        QueryHitsMaximumNumberValue = 10,
                        QueryHitsUnlimitedIndicator = false,
                        LastReturnedObjectID = new ObjectID(),
                    }
                };
                #endregion

                var queryResponse = await queryClient.FindByElementsAsync(queryPayload);
                var uuid = queryResponse.SalesOrderByElementsResponse_sync.SalesOrder?.FirstOrDefault()?.Item?.FirstOrDefault()?.PriceAndTaxCalculationItem?.ItemPriceComponent?.FirstOrDefault(x => x.Description.Value == "Cost Estimate")?.UUID;
                if (uuid == null)
                {
                    return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(queryResponse.SalesOrderByElementsResponse_sync?.Log.Item.Select(x => x.Note)));
                }

                // 修改預估成本金額
                request.Payload.SalesOrder.FirstOrDefault().Item.FirstOrDefault().PriceAndTaxCalculationItem.ItemPriceComponent.FirstOrDefault().UUID.Value = uuid.Value;
            }

            endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManageSalesOrderIn);
            var client = new ManageSalesOrderInClient(binding, endpointAddress);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.MaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.SalesOrderBundleMaintainConfirmation_sync?.SalesOrder == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.SalesOrderBundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.SalesOrderBundleMaintainConfirmation_sync.SalesOrder);
            }
        }
    }
}
