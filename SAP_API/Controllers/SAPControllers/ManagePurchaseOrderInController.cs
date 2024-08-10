using DotnetSdkUtilities.Factory.ResponseFactory;
using ManagePurchaseOrderInNS;
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
    public class ManagePurchaseOrderInController : ControllerBase
    {
        private readonly ILogger<ManagePurchaseOrderInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public ManagePurchaseOrderInController(ILogger<ManagePurchaseOrderInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 採購單-專案第三方
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/ManagePurchaseOrderIn/ProjectThirdPartyPurchaseOrder
        ///     {
        ///       "Payload": {
        ///         "PurchaseOrderMaintainBundle": [
        ///           {
        ///             "ObjectNodeSenderTechnicalID": "1",
        ///             "BusinessTransactionDocumentTypeCode": {
        ///               "Value": "001"
        ///             },
        ///             "OrderPurchaseOrderActionIndicator": true,
        ///             "OrderPurchaseOrderActionIndicatorSpecified": true,
        ///             "FinishDeliveryPOActionIndicator": false,
        ///             "FinishDeliveryPOActionIndicatorSpecified": true,
        ///             "FinishInvoicePOActionIndicator": false,
        ///             "FinishInvoicePOActionIndicatorSpecified": true,
        ///             "CurrencyCode": "TWD",
        ///             "BuyerParty": {
        ///               "ObjectNodePartyTechnicalID": "2",
        ///               "PartyKey": {
        ///                 "PartyID": {
        ///                   "Value": "AT"
        ///                 }
        ///               },
        ///               "actionCode": 0,
        ///               "actionCodeSpecified": true
        ///             },
        ///             "SellerParty": {
        ///               "ObjectNodePartyTechnicalID": "3",
        ///               "PartyKey": {
        ///                 "PartyID": {
        ///                   "Value": "B02009"
        ///                 }
        ///               },
        ///               "actionCode": 0,
        ///               "actionCodeSpecified": true
        ///             },
        ///             "EmployeeResponsibleParty": {
        ///               "ObjectNodePartyTechnicalID": "4",
        ///               "PartyKey": {
        ///                 "PartyID": {
        ///                   "Value": "E999916"
        ///                 }
        ///               },
        ///               "actionCode": 0,
        ///               "actionCodeSpecified": true
        ///             },
        ///             "ResponsiblePurchasingUnitParty": {
        ///               "ObjectNodePartyTechnicalID": "5",
        ///               "PartyKey": {
        ///                 "PartyID": {
        ///                   "Value": "MD30"
        ///                 }
        ///               },
        ///               "actionCode": 0,
        ///               "actionCodeSpecified": true
        ///             },
        ///             "AttachmentFolder": {
        ///               "Document": [
        ///                 {
        ///                   "VisibleIndicator": true,
        ///                   "VisibleIndicatorSpecified": true,
        ///                   "CategoryCode": "3",
        ///                   "TypeCode": {
        ///                     "Value": "10001"
        ///                   },
        ///                   "Name": "BPM串接_NAME_240502",
        ///                   "AlternativeName": "BPM串接表頭附件_Document Title文件標題_240502",
        ///                   "Description": {
        ///                     "languageCode": "ZF",
        ///                     "Value": "BPM串接表頭附件_comment留言_240502"
        ///                   },
        ///                   "ExternalLinkWebURI": "",
        ///                   "ActionCode": 0,
        ///                   "ActionCodeSpecified": true
        ///                 }
        ///               ],
        ///               "ActionCode": 0,
        ///               "ActionCodeSpecified": true
        ///             },
        ///             "TextCollection": {
        ///               "Text": [
        ///                 {
        ///                   "TypeCode": {
        ///                     "Value": "10011"
        ///                   },
        ///                   "LanguageCode": "ZF",
        ///                   "TextContent": {
        ///                     "Text": {
        ///                       "languageCode": "ZF",
        ///                       "Value": "BPM串接表頭註記_描述明細_240502"
        ///                     },
        ///                     "ActionCode": 0,
        ///                     "ActionCodeSpecified": true
        ///                   },
        ///                   "ActionCode": 0,
        ///                   "ActionCodeSpecified": true
        ///                 }
        ///               ],
        ///               "ActionCode": 0,
        ///               "ActionCodeSpecified": true
        ///             },
        ///             "DeliveryTerms": {
        ///               "IncoTerms": {
        ///                 "ClassificationCode": "EXW",
        ///                 "TransferLocationName": "TW"
        ///               },
        ///               "ActionCode": 0,
        ///               "ActionCodeSpecified": true
        ///             },
        ///             "CashDiscountTerms": {
        ///               "Code": {
        ///                 "Value": "Z460"
        ///               },
        ///               "ActionCode": 0,
        ///               "ActionCodeSpecified": true
        ///             },
        ///             "Item": [
        ///               {
        ///                 "ObjectNodeSenderTechnicalID": "6",
        ///                 "ItemID": "1",
        ///                 "BusinessTransactionDocumentItemTypeCode": "18",
        ///                 "Quantity": {
        ///                   "unitCode": "EA",
        ///                   "Value": 6
        ///                 },
        ///                 "ListUnitPrice": {
        ///                   "Amount": {
        ///                     "currencyCode": "TWD",
        ///                     "Value": 51000
        ///                   },
        ///                   "BaseQuantity": {
        ///                     "unitCode": "EA",
        ///                     "Value": 1
        ///                   },
        ///                   "BaseQuantityTypeCode": {
        ///                     "Value": "EA"
        ///                   }
        ///                 },
        ///                 "DeliveryPeriod": {
        ///                   "StartDateTime": {
        ///                     "timeZoneCode": "UTC+8",
        ///                     "Value": "2024-05-10T18:00:00+08:00"
        ///                   }
        ///                 },
        ///                 "ThirdPartyDealIndicator": true,
        ///                 "ThirdPartyDealIndicatorSpecified": true,
        ///                 "FollowUpDelivery": {
        ///                   "RequirementCode": 2,
        ///                   "RequirementCodeSpecified": true
        ///                 },
        ///                 "FollowUpInvoice": {
        ///                   "RequirementCode": 2,
        ///                   "RequirementCodeSpecified": true
        ///                 },
        ///                 "ItemProduct": {
        ///                   "CashDiscountDeductibleIndicator": false,
        ///                   "ProductKey": {
        ///                     "ProductTypeCode": "1",
        ///                     "ProductIdentifierTypeCode": "1",
        ///                     "ProductID": {
        ///                       "Value": "PECNPR0001"
        ///                     }
        ///                   },
        ///                   "actionCode": 0,
        ///                   "actionCodeSpecified": true
        ///                 },
        ///                 "ShipToLocation": {
        ///                   "ObjectNodePartyTechnicalID": "7",
        ///                   "LocationID": {
        ///                     "Value": "AT"
        ///                   },
        ///                   "actionCode": 0,
        ///                   "actionCodeSpecified": true
        ///                 },
        ///                 "EndBuyerParty": {
        ///                   "ObjectNodePartyTechnicalID": "10",
        ///                   "PartyKey": {
        ///                     "PartyTypeCode": {
        ///                       "Value": "159"
        ///                     },
        ///                     "PartyID": {
        ///                       "Value": "E001"
        ///                     }
        ///                   },
        ///                   "actionCode": 0,
        ///                   "actionCodeSpecified": true
        ///                 },
        ///                 "ProductRecipientParty": {
        ///                   "ObjectNodePartyTechnicalID": "8",
        ///                   "PartyKey": {
        ///                     "PartyTypeCode": {
        ///                       "Value": "147"
        ///                     },
        ///                     "PartyID": {
        ///                       "Value": "E210802"
        ///                     }
        ///                   },
        ///                   "actionCode": 0,
        ///                   "actionCodeSpecified": true
        ///                 },
        ///                 "RequestorParty": {
        ///                   "ObjectNodePartyTechnicalID": "9",
        ///                   "PartyKey": {
        ///                     "PartyTypeCode": {
        ///                       "Value": "147"
        ///                     },
        ///                     "PartyID": {
        ///                       "Value": "E210902"
        ///                     }
        ///                   },
        ///                   "actionCode": 0,
        ///                   "actionCodeSpecified": true
        ///                 },
        ///                 "ItemAccountingCodingBlockDistribution": {
        ///                   "CompanyID": "AT",
        ///                   "AccountingCodingBlockAssignment": [
        ///                     {
        ///                       "AccountingCodingBlockTypeCode": {
        ///                         "Value": "PRO"
        ///                       },
        ///                       "ProjectTaskKey": {
        ///                         "TaskID": {
        ///                           "Value": "AIN23013-E5"
        ///                         }
        ///                       },
        ///                       "SalesOrderReference": {
        ///                         "ID": {
        ///                           "Value": "1601"
        ///                         },
        ///                         "ItemID": "10"
        ///                       },
        ///                       "ActionCode": 0,
        ///                       "ActionCodeSpecified": true
        ///                     }
        ///                   ],
        ///                   "ActionCode": 0,
        ///                   "ActionCodeSpecified": true
        ///                 },
        ///                 "ItemAttachmentFolder": {
        ///                   "Document": [
        ///                     {
        ///                       "VisibleIndicator": true,
        ///                       "VisibleIndicatorSpecified": true,
        ///                       "CategoryCode": "3",
        ///                       "TypeCode": {
        ///                         "Value": "10001"
        ///                       },
        ///                       "Name": "BPM串接_表身NAME_2400502",
        ///                       "AlternativeName": "BPM串接表身附件_240502",
        ///                       "Description": {
        ///                         "languageCode": "ZF",
        ///                         "Value": "BPM串接表身附件_comment留言_240502"
        ///                       },
        ///                       "ExternalLinkWebURI": "",
        ///                       "ActionCode": 0,
        ///                       "ActionCodeSpecified": true
        ///                     }
        ///                   ],
        ///                   "ActionCode": 0,
        ///                   "ActionCodeSpecified": true
        ///                 },
        ///                 "ItemTextCollection": {
        ///                   "Text": [
        ///                     {
        ///                       "TypeCode": {
        ///                         "Value": "10011"
        ///                       },
        ///                       "LanguageCode": "ZF",
        ///                       "TextContent": {
        ///                         "Text": {
        ///                           "languageCode": "ZF",
        ///                           "Value": "BPM串接表身註記_描述明細_240502"
        ///                         },
        ///                         "ActionCode": 0,
        ///                         "ActionCodeSpecified": true
        ///                       },
        ///                       "ActionCode": 0,
        ///                       "ActionCodeSpecified": true
        ///                     }
        ///                   ],
        ///                   "ActionCode": 0,
        ///                   "ActionCodeSpecified": true
        ///                 },
        ///                 "ItemTaxCalculation": {
        ///                   "CountryCode": "TW",
        ///                   "TaxationCharacteristicsCode": {
        ///                     "listID": "TW",
        ///                     "Value": "P21"
        ///                   },
        ///                   "actionCode": 0,
        ///                   "actionCodeSpecified": true
        ///                 },
        ///                 "PurchaserequestSAP": "2144",
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true
        ///               }
        ///             ],
        ///             "PRJ_NAM": "BPM_POTEST_0502接續商品收貨",
        ///             "PjName": "BPM_POTEST_0502",
        ///             "actionCode": 0,
        ///             "actionCodeSpecified": true,
        ///             "ItemListCompleteTransmissionIndicator": true,
        ///             "ItemListCompleteTransmissionIndicatorSpecified": true
        ///           }
        ///         ]
        ///       },
        ///       "User": "Tony"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<PurchaseOrderMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> ProjectThirdPartyPurchaseOrder([FromBody] ProjectThirdPartyPurchaseOrderRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManagePurchaseOrderIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManagePurchaseOrderInClient(binding, endpointAddress);

            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.ManagePurchaseOrderInMaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.PurchaseOrderBundleMaintainConfirmation_sync?.PurchaseOrder == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.PurchaseOrderBundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.PurchaseOrderBundleMaintainConfirmation_sync.PurchaseOrder);
            }
        }

        /// <summary>
        /// 採購單-一般庫存採購
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/ManagePurchaseOrderIn/GeneralInventoryProcurement
        ///     {
        ///        "Payload": {
        ///           "PurchaseOrderMaintainBundle": [
        ///              {
        ///                 "BusinessTransactionDocumentTypeCode": {
        ///                    "Value": "001"
        ///                 },
        ///                 "OrderPurchaseOrderActionIndicator": true,
        ///                 "OrderPurchaseOrderActionIndicatorSpecified": true,
        ///                 "FinishDeliveryPOActionIndicator": false,
        ///                 "FinishDeliveryPOActionIndicatorSpecified": true,
        ///                 "FinishInvoicePOActionIndicator": false,
        ///                 "FinishInvoicePOActionIndicatorSpecified": true,
        ///                 "CurrencyCode": "USD",
        ///                 "BuyerParty": {
        ///                    "PartyKey": {
        ///                       "PartyID": {
        ///                          "Value": "AT"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "SellerParty": {
        ///                    "PartyKey": {
        ///                       "PartyID": {
        ///                          "Value": "B02007"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "EmployeeResponsibleParty": {
        ///                    "PartyKey": {
        ///                       "PartyID": {
        ///                          "Value": "E999916"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "ResponsiblePurchasingUnitParty": {
        ///                    "PartyKey": {
        ///                       "PartyID": {
        ///                          "Value": "MD30"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "AttachmentFolder": {
        ///                    "Document": [
        ///                       {
        ///                          "VisibleIndicator": true,
        ///                          "VisibleIndicatorSpecified": true,
        ///                          "CategoryCode": "3",
        ///                          "TypeCode": {
        ///                             "Value": "10001"
        ///                          },
        ///                          "Name": "BPM串接_NAME_240423",
        ///                          "AlternativeName": "BPM串接表頭附件_Document Title文件標題_240423",
        ///                          "Description": {
        ///                             "languageCode": "ZF",
        ///                             "Value": "BPM串接表頭附件_comment留言_240423"
        ///                          },
        ///                          "ExternalLinkWebURI": "https://www.ampower.com.tw/",
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       }
        ///                    ],
        ///                    "ActionCode": 0,
        ///                    "ActionCodeSpecified": true
        ///                 },
        ///                 "TextCollection": {
        ///                    "Text": [
        ///                       {
        ///                          "TypeCode": {
        ///                             "Value": "10011"
        ///                          },
        ///                          "LanguageCode": "ZF",
        ///                          "TextContent": {
        ///                             "Text": {
        ///                                "languageCode": "ZF",
        ///                                "Value": "BPM串接表頭註記_描述明細_240423"
        ///                             },
        ///                             "ActionCode": 0,
        ///                             "ActionCodeSpecified": true
        ///                          },
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       }
        ///                    ],
        ///                    "ActionCode": 0,
        ///                    "ActionCodeSpecified": true
        ///                 },
        ///                 "DeliveryTerms": {
        ///                    "IncoTerms": {
        ///                       "ClassificationCode": "EXW",
        ///                       "TransferLocationName": "TW"
        ///                    },
        ///                    "ActionCode": 0,
        ///                    "ActionCodeSpecified": true
        ///                 },
        ///                 "CashDiscountTerms": {
        ///                    "Code": {
        ///                       "Value": "Z420"
        ///                    },
        ///                    "ActionCode": 0,
        ///                    "ActionCodeSpecified": true
        ///                 },
        ///                 "Item": [
        ///                    {
        ///                       "ItemID": "1",
        ///                       "BusinessTransactionDocumentItemTypeCode": "18",
        ///                       "Quantity": {
        ///                          "unitCode": "EA",
        ///                          "Value": 3
        ///                       },
        ///                       "ListUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "USD",
        ///                             "Value": 24.41
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "unitCode": "EA",
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "EA"
        ///                          }
        ///                       },
        ///                       "DeliveryPeriod": {
        ///                          "StartDateTime": {
        ///                             "timeZoneCode": "UTC+8",
        ///                             "Value": "2024-04-26T18:00:00+08:00"
        ///                          }
        ///                       },
        ///                       "DirectMaterialIndicator": true,
        ///                       "DirectMaterialIndicatorSpecified": true,
        ///                       "FollowUpDelivery": {
        ///                          "RequirementCode": 2,
        ///                          "RequirementCodeSpecified": true
        ///                       },
        ///                       "FollowUpInvoice": {
        ///                          "RequirementCode": 2,
        ///                          "RequirementCodeSpecified": true
        ///                       },
        ///                       "ItemProduct": {
        ///                          "CashDiscountDeductibleIndicator": false,
        ///                          "ProductKey": {
        ///                             "ProductTypeCode": "1",
        ///                             "ProductIdentifierTypeCode": "1",
        ///                             "ProductID": {
        ///                                "Value": "FTKLLF0007"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "ShipToLocation": {
        ///                          "LocationID": {
        ///                             "Value": "AT"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "RequestorParty": {
        ///                          "ObjectNodePartyTechnicalID": "1",
        ///                          "PartyKey": {
        ///                             "PartyTypeCode": {
        ///                                "Value": "147"
        ///                             },
        ///                             "PartyID": {
        ///                                "Value": "E210902"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "ItemAttachmentFolder": {
        ///                          "Document": [
        ///                             {
        ///                                "VisibleIndicator": true,
        ///                                "VisibleIndicatorSpecified": true,
        ///                                "CategoryCode": "3",
        ///                                "TypeCode": {
        ///                                   "Value": "10001"
        ///                                },
        ///                                "Name": "BPM串接_表身NAME_240423",
        ///                                "AlternativeName": "BPM串接表身附件_240423",
        ///                                "Description": {
        ///                                   "languageCode": "ZF",
        ///                                   "Value": "BPM串接表身附件_comment留言_240423"
        ///                                },
        ///                                "ExternalLinkWebURI": "",
        ///                                "ActionCode": 0,
        ///                                "ActionCodeSpecified": true
        ///                             }
        ///                          ],
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       },
        ///                       "ItemTextCollection": {
        ///                          "Text": [
        ///                             {
        ///                                "TypeCode": {
        ///                                   "Value": "10011"
        ///                                },
        ///                                "LanguageCode": "ZF",
        ///                                "TextContent": {
        ///                                   "Text": {
        ///                                      "languageCode": "ZF",
        ///                                      "Value": "BPM串接表身註記_描述明細_240423"
        ///                                   },
        ///                                   "ActionCode": 0,
        ///                                   "ActionCodeSpecified": true
        ///                                },
        ///                                "ActionCode": 0,
        ///                                "ActionCodeSpecified": true
        ///                             }
        ///                          ],
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       },
        ///                       "ItemTaxCalculation": {
        ///                          "CountryCode": "TW",
        ///                          "TaxationCharacteristicsCode": {
        ///                             "listID": "TW",
        ///                             "Value": "F28"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    },
        ///                    {
        ///                       "ItemID": "2",
        ///                       "BusinessTransactionDocumentItemTypeCode": "18",
        ///                       "Quantity": {
        ///                          "unitCode": "EA",
        ///                          "Value": 5
        ///                       },
        ///                       "ListUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "USD",
        ///                             "Value": 262.09
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "unitCode": "EA",
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "EA"
        ///                          }
        ///                       },
        ///                       "DeliveryPeriod": {
        ///                          "StartDateTime": {
        ///                             "timeZoneCode": "UTC+8",
        ///                             "Value": "2024-04-26T18:00:00+08:00"
        ///                          }
        ///                       },
        ///                       "DirectMaterialIndicator": true,
        ///                       "DirectMaterialIndicatorSpecified": true,
        ///                       "FollowUpDelivery": {
        ///                          "RequirementCode": 2,
        ///                          "RequirementCodeSpecified": true
        ///                       },
        ///                       "FollowUpInvoice": {
        ///                          "RequirementCode": 2,
        ///                          "RequirementCodeSpecified": true
        ///                       },
        ///                       "ItemProduct": {
        ///                          "CashDiscountDeductibleIndicator": false,
        ///                          "ProductKey": {
        ///                             "ProductTypeCode": "1",
        ///                             "ProductIdentifierTypeCode": "1",
        ///                             "ProductID": {
        ///                                "Value": "PCKLOT0001"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "ShipToLocation": {
        ///                          "LocationID": {
        ///                             "Value": "AT"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "RequestorParty": {
        ///                          "PartyKey": {
        ///                             "PartyTypeCode": {
        ///                                "Value": "147"
        ///                             },
        ///                             "PartyID": {
        ///                                "Value": "E210902"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "ItemTaxCalculation": {
        ///                          "CountryCode": "TW",
        ///                          "TaxationCharacteristicsCode": {
        ///                             "listID": "TW",
        ///                             "Value": "F28"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "PRJ_NAM": "ALICE_API一般庫存採購06",
        ///                 "SU_Memo": "特別備註_API",
        ///                 "AppointedForwarder": "141",
        ///                 "CommissionOrder": "125",
        ///                 "ContactPerson": "Jamin Lee #1234",
        ///                 "Destination": "目的地_安葆台灣AT",
        ///                 "DiscountAmount": {
        ///                    "currencyCode": "USD",
        ///                    "Value": 10
        ///                 },
        ///                 "ExWork": "104",
        ///                 "Forwarder": "貨運代理商_SOETEK-TEST",
        ///                 "Freight": "137",
        ///                 "IfOthersplsspecify": "20240423-001",
        ///                 "Insurance": "保險號666666",
        ///                 "KOHLERQuotationRef": "121",
        ///                 "KOHLERShipTo": "118",
        ///                 "PartialShipmentAllow": "128",
        ///                 "PurchaseOrderNo": "PO#20240423-API001",
        ///                 "RequestedExFactoryDate": "2024-04-26",
        ///                 "ShipVia": "新加坡",
        ///                 "PjName": "ALICE_TEST_0423_06",
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true,
        ///                 "ItemListCompleteTransmissionIndicator": true,
        ///                 "ItemListCompleteTransmissionIndicatorSpecified": true
        ///              }
        ///           ]
        ///        },
        ///        "User": "Perry"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<PurchaseOrderMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> GeneralInventoryProcurement([FromBody] ProjectThirdPartyPurchaseOrderRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManagePurchaseOrderIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManagePurchaseOrderInClient(binding, endpointAddress);

            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.ManagePurchaseOrderInMaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.PurchaseOrderBundleMaintainConfirmation_sync?.PurchaseOrder == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.PurchaseOrderBundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.PurchaseOrderBundleMaintainConfirmation_sync.PurchaseOrder);
            }
        }
    }
}
