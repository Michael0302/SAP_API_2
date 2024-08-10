using DotnetSdkUtilities.Factory.ResponseFactory;
using ManageSupplierInvoiceInNS;
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
    [ApiController]
    [Route("api/SAP/[controller]/[action]")]
    public class ManageSupplierInvoiceInController : ControllerBase
    {
        private readonly ILogger<ManageSupplierInvoiceInController> _logger;
        private readonly IMyResponseFactory _myResponseFactory;
        private readonly IOptionsMonitor<Settings> _setting;

        public ManageSupplierInvoiceInController(ILogger<ManageSupplierInvoiceInController> logger, IMyResponseFactory myResponseFactory, IOptionsMonitor<Settings> setting)
        {
            _logger = logger;
            _myResponseFactory = myResponseFactory;
            _setting = setting;
        }

        /// <summary>
        /// 供應商發票-專案第三方
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/ManageSupplierInvoiceIn/ProjectThirdPartySupplierInvoice 
        ///     {
        ///        "Payload": {
        ///           "SupplierInvoice": [
        ///              {
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true,
        ///                 "ObjectNodeSenderTechnicalID": "",
        ///                 "ChangeStateID": "",
        ///                 "BusinessTransactionDocumentTypeCode": {
        ///                    "Value": "004"
        ///                 },
        ///                 "MEDIUM_Name": {
        ///                    "Value": "ALICE_PO#2888"
        ///                 },
        ///                 "Date": "2024-04-09",
        ///                 "ReceiptDate": "2024-04-10",
        ///                 "TransactionDate": "2024-04-10",
        ///                 "DocumentItemGrossAmountIndicator": false,
        ///                 "GrossAmount": {
        ///                    "currencyCode": "USD",
        ///                    "Value": 42883.12
        ///                 },
        ///                 "TaxAmount": {
        ///                    "currencyCode": "USD",
        ///                    "Value": 0
        ///                 },
        ///                 "Status": {
        ///                    "DataEntryProcessingStatusCode": 1
        ///                 },
        ///                 "CustomerInvoiceReference": {
        ///                    "BusinessTransactionDocumentReference": {
        ///                       "ID": {
        ///                          "Value": "ALICE_IV20240409AAA"
        ///                       },
        ///                       "TypeCode": {
        ///                          "Value": "28"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "BuyerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "200"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "AT"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "SellerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "147"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "B02008"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "CashDiscountTerms": {
        ///                    "Code": {
        ///                       "Value": "Z420"
        ///                    },
        ///                    "ActionCode": 0,
        ///                    "ActionCodeSpecified": true
        ///                 },
        ///                 "ExchangeRate": [
        ///                    {
        ///                       "ExchangeRate": {
        ///                          "UnitCurrency": "USD",
        ///                          "QuotedCurrency": "TWD",
        ///                          "Rate": 32
        ///                       },
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "Item": [
        ///                    {
        ///                       "ItemID": "01",
        ///                       "BusinessTransactionDocumentItemTypeCode": "002",
        ///                       "Quantity": {
        ///                          "Value": 73
        ///                       },
        ///                       "QuantityTypeCode": {
        ///                          "Value": "EA"
        ///                       },
        ///                       "NetAmount": {
        ///                          "currencyCode": "USD",
        ///                          "Value": 42883.12
        ///                       },
        ///                       "NetUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "USD",
        ///                             "Value": 587.44
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "EA"
        ///                          }
        ///                       },
        ///                       "Product": {
        ///                          "CashDiscountDeductibleIndicator": true,
        ///                          "ProductKey": {
        ///                             "ProductTypeCode": "1",
        ///                             "ProductIdentifierTypeCode": "1",
        ///                             "ProductID": {
        ///                                "Value": "OWKLCL0001"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "AccountingCodingBlockDistribution": {
        ///                          "AccountingCodingBlockAssignment": [
        ///                             {
        ///                                "AccountingCodingBlockTypeCode": {
        ///                                   "Value": "PRO"
        ///                                },
        ///                                "ProjectTaskKey": {
        ///                                   "TaskID": {
        ///                                      "Value": "AIN22032-B2-1"
        ///                                   }
        ///                                },
        ///                                "ProjectReference": {
        ///                                   "ProjectID": {
        ///                                      "Value": "AIN22032"
        ///                                   },
        ///                                   "ProjectElementID": {
        ///                                      "Value": "AIN22032-B2-1"
        ///                                   }
        ///                                },
        ///                                "SalesOrderReference": {
        ///                                   "ID": {
        ///                                      "Value": "339"
        ///                                   },
        ///                                   "ItemID": "10"
        ///                                },
        ///                                "ActionCode": 0,
        ///                                "ActionCodeSpecified": true
        ///                             }
        ///                          ],
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       },
        ///                       "ProductTax": {
        ///                          "ProductTaxationCharacteristicsCode": {
        ///                             "listID": "",
        ///                             "Value": "F28"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "PurchaseOrderReference": {
        ///                          "BusinessTransactionDocumentReference": {
        ///                             "ID": {
        ///                                "Value": "2888"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "APnote": "創建者備註_ALICE",
        ///                 "PRJ_NAM": "案件編號_ALICE_TEST01",
        ///                 "PjName": "案件名稱_ALICE_TEST01",
        ///                 "REQUNIT": "MD30"
        ///              }
        ///           ]
        ///        },
        ///        "User": "string"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<SupplierInvoiceMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> ProjectThirdPartySupplierInvoice([FromBody] ProjectThirdPartySupplierInvoiceRequestRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManageSupplierInvoiceIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManageSupplierInvoiceInClient(binding, endpointAddress);
            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.MaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.SupplierInvoiceBundleMaintainConfirmation_sync?.SupplierInvoice == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.SupplierInvoiceBundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.SupplierInvoiceBundleMaintainConfirmation_sync.SupplierInvoice);
            }
        }

        /// <summary>
        /// 供應商發票-費用(計畫部)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/ManageSupplierInvoiceIn/ProjectThirdPartySupplierInvoice
        ///     {
        ///        "Payload": {
        ///           "SupplierInvoice": [
        ///              {
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true,
        ///                 "BusinessTransactionDocumentTypeCode": {
        ///                    "Value": "004"
        ///                 },
        ///                 "MEDIUM_Name": {
        ///                    "Value": "ALICE_PO#2917_0506001"
        ///                 },
        ///                 "Date": "2024-05-06",
        ///                 "ReceiptDate": "2024-05-06",
        ///                 "TransactionDate": "2024-05-06",
        ///                 "DocumentItemGrossAmountIndicator": false,
        ///                 "GrossAmount": {
        ///                    "currencyCode": "TWD",
        ///                    "Value": 346500
        ///                 },
        ///                 "TaxAmount": {
        ///                    "currencyCode": "TWD",
        ///                    "Value": 16500
        ///                 },
        ///                 "Status": {
        ///                    "DataEntryProcessingStatusCode": 3
        ///                 },
        ///                 "CustomerInvoiceReference": {
        ///                    "BusinessTransactionDocumentReference": {
        ///                       "ID": {
        ///                          "Value": "ALICE_PO#2917_0506001"
        ///                       },
        ///                       "TypeCode": {
        ///                          "Value": "28"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "BuyerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "200"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "AT"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "SellerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "147"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "A03023"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
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
        ///                       "ItemID": "01",
        ///                       "BusinessTransactionDocumentItemTypeCode": "002",
        ///                       "Quantity": {
        ///                          "Value": 3
        ///                       },
        ///                       "QuantityTypeCode": {
        ///                          "Value": "LS"
        ///                       },
        ///                       "NetAmount": {
        ///                          "currencyCode": "TWD",
        ///                          "Value": 330000
        ///                       },
        ///                       "NetUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "TWD",
        ///                             "Value": 110000
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "EA"
        ///                          }
        ///                       },
        ///                       "Product": {
        ///                          "CashDiscountDeductibleIndicator": false,
        ///                          "ProductKey": {
        ///                             "ProductTypeCode": "1",
        ///                             "ProductIdentifierTypeCode": "1",
        ///                             "ProductID": {
        ///                                "Value": "LABFPJ0012"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "AccountingCodingBlockDistribution": {
        ///                          "AccountingCodingBlockAssignment": [
        ///                             {
        ///                                "AccountingCodingBlockTypeCode": {
        ///                                   "Value": "CC"
        ///                                },
        ///                                "Percent": "100",
        ///                                "Amount": {
        ///                                   "CurrencyCode": "TWD",
        ///                                   "Value": "330000"
        ///                                },
        ///                                "Quantity": {
        ///                                   "UnitCode": "LS",
        ///                                   "Value": "3"
        ///                                },
        ///                                "GeneralLedgerAccountAliasCode": {
        ///                                   "Value": "618900"
        ///                                },
        ///                                "CostCentreID": "AT-DN00",
        ///                                "ActionCode": 0,
        ///                                "ActionCodeSpecified": true
        ///                             }
        ///                          ],
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       },
        ///                       "ProductTax": {
        ///                          "ProductTaxationCharacteristicsCode": {
        ///                             "listID": "",
        ///                             "Value": "P21"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "PurchaseOrderReference": {
        ///                          "BusinessTransactionDocumentReference": {
        ///                             "ID": {
        ///                                "Value": "2917"
        ///                             },
        ///                             "ItemID": "1"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "APnote": "",
        ///                 "PRJ_NAM": "案件編號_EX_BPMTEST01",
        ///                 "PjName": "案件名稱_EX_BPMTEST01",
        ///                 "REQUNIT": "MD30"
        ///              }
        ///           ]
        ///        },
        ///        "User": "string"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<SupplierInvoiceMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> CostSupplierInvoice([FromBody] ProjectThirdPartySupplierInvoiceRequestRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManageSupplierInvoiceIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManageSupplierInvoiceInClient(binding, endpointAddress);
            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.MaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.SupplierInvoiceBundleMaintainConfirmation_sync?.SupplierInvoice == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.SupplierInvoiceBundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.SupplierInvoiceBundleMaintainConfirmation_sync.SupplierInvoice);
            }
        }

        /// <summary>
        /// 供應商發票-員工報銷
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/ManageSupplierInvoiceIn/EmployeeReimburseSupplierInvoice 
        ///     {
        ///        "Payload": {
        ///           "SupplierInvoice": [
        ///              {
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true,
        ///                 "BusinessTransactionDocumentTypeCode": {
        ///                    "Value": "004"
        ///                 },
        ///                 "MEDIUM_Name": {
        ///                    "Value": "BPM測試串接_USER帳號"
        ///                 },
        ///                 "Date": "2024-07-08",
        ///                 "ReceiptDate": "2024-07-08",
        ///                 "TransactionDate": "2024-07-08",
        ///                 "DocumentItemGrossAmountIndicator": false,
        ///                 "GrossAmount": {
        ///                    "currencyCode": "TWD",
        ///                    "Value": 2100
        ///                 },
        ///                 "TaxAmount": {
        ///                    "currencyCode": "TWD",
        ///                    "Value": 100
        ///                 },
        ///                 "Status": {
        ///                    "DataEntryProcessingStatusCode": 3
        ///                 },
        ///                 "CustomerInvoiceReference": {
        ///                    "BusinessTransactionDocumentReference": {
        ///                       "ID": {
        ///                          "Value": "ALICE_0708001"
        ///                       },
        ///                       "TypeCode": {
        ///                          "Value": "28"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "BuyerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "200"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "AT"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "SellerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "147"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "D99001"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
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
        ///                       "ItemID": "01",
        ///                       "BusinessTransactionDocumentItemTypeCode": "002",
        ///                       "Quantity": {
        ///                          "UnitCode": "LS",
        ///                          "Value": 73
        ///                       },
        ///                       "QuantityTypeCode": {
        ///                          "Value": "LS"
        ///                       },
        ///                       "SHORT_Description": {
        ///                          "Value": "費用測試-0708"
        ///                       },
        ///                       "NetAmount": {
        ///                          "currencyCode": "TWD",
        ///                          "Value": 2000
        ///                       },
        ///                       "NetUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "TWD",
        ///                             "Value": 2000
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "LS"
        ///                          }
        ///                       },
        ///                       "Product": {
        ///                          "CashDiscountDeductibleIndicator": false,
        ///                          "ProductCategoryIDKey": {
        ///                             "ProductCategoryInternalID": "MISC"
        ///                          },
        ///                          "ProductKey": {
        ///                             "ProductTypeCode": "1",
        ///                             "ProductIdentifierTypeCode": "1"
        ///                             
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "AccountingCodingBlockDistribution": {
        ///                          "AccountingCodingBlockAssignment": [
        ///                             {
        ///                                "AccountingCodingBlockTypeCode": {
        ///                                   "Value": "CC"
        ///                                },
        ///                                "Percent": "100",
        ///                                "Amount": {
        ///                                   "CurrencyCode": "TWD",
        ///                                   "Value": "20000"
        ///                                },
        ///                                "Quantity": {
        ///                                   "UnitCode": "LS",
        ///                                   "Value": "1"
        ///                                },
        ///                                "GeneralLedgerAccountAliasCode": {
        ///                                   "Value": "618900"
        ///                                },
        ///                                "CostCentreID": "MD20",
        ///                                "ActionCode": 0,
        ///                                "ActionCodeSpecified": true
        ///                             }
        ///                          ],
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       },
        ///                       "ProductTax": {
        ///                          "ProductTaxationCharacteristicsCode": {
        ///                             "listID": "",
        ///                             "Value": "P21"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "PurchaseOrderReference": {
        ///                          "BusinessTransactionDocumentReference": {
        ///                             "ID": {
        ///                                "Value": "2888"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "APnote": "",
        ///                 "PRJ_NAM": "案件編號_EX_BPMTEST0708",
        ///                 "PjName": "案件名稱_EX_BPMTEST0708",
        ///                 "REQUNIT": "MD20"
        ///              }
        ///           ]
        ///        },
        ///        "User": "string"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<SupplierInvoiceMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> EmployeeReimburseSupplierInvoice([FromBody] ProjectThirdPartySupplierInvoiceRequestRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManageSupplierInvoiceIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManageSupplierInvoiceInClient(binding, endpointAddress);
            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.MaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.SupplierInvoiceBundleMaintainConfirmation_sync?.SupplierInvoice == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.SupplierInvoiceBundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.SupplierInvoiceBundleMaintainConfirmation_sync.SupplierInvoice);
            }
        }

        /// <summary>
        /// 供應商發票-一般庫存
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/ManageSupplierInvoiceIn/NormalStockSupplierInvoice 
        ///     {
        ///        "Payload": {
        ///           "SupplierInvoice": [
        ///              {
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true,
        ///                 "BusinessTransactionDocumentTypeCode": {
        ///                    "Value": "004"
        ///                 },
        ///                 "MEDIUM_Name": {
        ///                    "Value": "ALICE_PO#2903_0506"
        ///                 },
        ///                 "Date": "2024-05-06",
        ///                 "ReceiptDate": "2024-05-06",
        ///                 "TransactionDate": "2024-05-06",
        ///                 "DocumentItemGrossAmountIndicator": false,
        ///                 "GrossAmount": {
        ///                    "currencyCode": "USD",
        ///                    "Value": 1383.68
        ///                 },
        ///                 "TaxAmount": {
        ///                    "currencyCode": "USD",
        ///                    "Value": 0
        ///                 },
        ///                 "Status": {
        ///                    "DataEntryProcessingStatusCode": 3
        ///                 },
        ///                 "CustomerInvoiceReference": {
        ///                    "BusinessTransactionDocumentReference": {
        ///                       "ID": {
        ///                          "Value": "ALICE_PO#2903_0506"
        ///                       },
        ///                       "TypeCode": {
        ///                          "Value": "28"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "BuyerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "200"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "AT"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "SellerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "147"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "B02007"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "CashDiscountTerms": {
        ///                    "Code": {
        ///                       "Value": "Z430"
        ///                    },
        ///                    "ActionCode": 0,
        ///                    "ActionCodeSpecified": true
        ///                 },
        ///                 "Item": [
        ///                    {
        ///                       "ItemID": "01",
        ///                       "BusinessTransactionDocumentItemTypeCode": "002",
        ///                       "Quantity": {
        ///                          "Value": 73
        ///                       },
        ///                       "QuantityTypeCode": {
        ///                          "Value": "EA"
        ///                       },
        ///                       "NetAmount": {
        ///                          "currencyCode": "USD",
        ///                          "Value": 73.23
        ///                       },
        ///                       "NetUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "USD",
        ///                             "Value": 24.41
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "EA"
        ///                          }
        ///                       },
        ///                       "Product": {
        ///                          "CashDiscountDeductibleIndicator": false,
        ///                          "ProductKey": {
        ///                             "ProductTypeCode": "1",
        ///                             "ProductIdentifierTypeCode": "1",
        ///                             "ProductID": {
        ///                                 "Value": "FTKLLF0007"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "ProductTax": {
        ///                          "ProductTaxationCharacteristicsCode": {
        ///                             "listID": "",
        ///                             "Value": "F28"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "PurchaseOrderReference": {
        ///                          "BusinessTransactionDocumentReference": {
        ///                             "ID": {
        ///                                "Value": "2903",
        ///                                "ItemID": "1"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    },
        ///                    
        ///                    {
        ///                       "ItemID": "02",
        ///                       "BusinessTransactionDocumentItemTypeCode": "002",
        ///                       "Quantity": {
        ///                          "Value": 5
        ///                       },
        ///                       "QuantityTypeCode": {
        ///                          "Value": "EA"
        ///                       },
        ///                       "NetAmount": {
        ///                          "currencyCode": "USD",
        ///                          "Value": 1310.45
        ///                       },
        ///                       "NetUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "USD",
        ///                             "Value": 262.09
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "EA"
        ///                          }
        ///                       },
        ///                       "Product": {
        ///                          "CashDiscountDeductibleIndicator": false,
        ///                          "ProductKey": {
        ///                             "ProductTypeCode": "1",
        ///                             "ProductIdentifierTypeCode": "1",
        ///                             "ProductID": {
        ///                                 "Value": "PCKLOT0001"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "ProductTax": {
        ///                          "ProductTaxationCharacteristicsCode": {
        ///                             "listID": "",
        ///                             "Value": "F28"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "PurchaseOrderReference": {
        ///                          "BusinessTransactionDocumentReference": {
        ///                             "ID": {
        ///                                "Value": "2903",
        ///                                "ItemID": "2"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "APnote": "",
        ///                 "PRJ_NAM": "案件編號_PO#2903",
        ///                 "PjName": "",
        ///                 "REQUNIT": "MD30"
        ///              }
        ///           ]
        ///        },
        ///        "User": "string"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<SupplierInvoiceMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> NormalStockSupplierInvoice([FromBody] ProjectThirdPartySupplierInvoiceRequestRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManageSupplierInvoiceIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManageSupplierInvoiceInClient(binding, endpointAddress);
            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.MaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.SupplierInvoiceBundleMaintainConfirmation_sync?.SupplierInvoice == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.SupplierInvoiceBundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.SupplierInvoiceBundleMaintainConfirmation_sync.SupplierInvoice);
            }
        }

        /// <summary>
        /// 供應商發票-固資
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/SAP/ManageSupplierInvoiceIn/FixedAssetsSupplierInvoice 
        ///     {
        ///        "Payload": {
        ///           "SupplierInvoice": [
        ///              {
        ///                 "actionCode": 0,
        ///                 "actionCodeSpecified": true,
        ///                 "BusinessTransactionDocumentTypeCode": {
        ///                    "Value": "004"
        ///                 },
        ///                 "MEDIUM_Name": {
        ///                    "Value": "ALICE_PO#2926_0506"
        ///                 },
        ///                 "Date": "2024-05-06",
        ///                 "ReceiptDate": "2024-05-06",
        ///                 "TransactionDate": "2024-05-06",
        ///                 "DocumentItemGrossAmountIndicator": false,
        ///                 "GrossAmount": {
        ///                    "currencyCode": "TWD",
        ///                    "Value": 129360
        ///                 },
        ///                 "TaxAmount": {
        ///                    "currencyCode": "TWD",
        ///                    "Value": 6160
        ///                 },
        ///                 "Status": {
        ///                    "DataEntryProcessingStatusCode": 3
        ///                 },
        ///                 "CustomerInvoiceReference": {
        ///                    "BusinessTransactionDocumentReference": {
        ///                       "ID": {
        ///                          "Value": "ALICE_PO#2926_0506"
        ///                       },
        ///                       "TypeCode": {
        ///                          "Value": "28"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "BuyerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "200"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "AT"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "SellerParty": {
        ///                    "PartyKey": {
        ///                       "PartyTypeCode": {
        ///                          "Value": "147"
        ///                       },
        ///                       "PartyID": {
        ///                          "Value": "D99001"
        ///                       }
        ///                    },
        ///                    "actionCode": 0,
        ///                    "actionCodeSpecified": true
        ///                 },
        ///                 "CashDiscountTerms": {
        ///                    "Code": {
        ///                       "Value": "Z460"
        ///                    },
        ///                    "ActionCode": 0,
        ///                    "ActionCodeSpecified": true
        ///                 },
        ///                 "Item": [
        ///                    {
        ///                       "ItemID": "01",
        ///                       "BusinessTransactionDocumentItemTypeCode": "002",
        ///                       "Quantity": {
        ///                          "Value": 1
        ///                       },
        ///                       "QuantityTypeCode": {
        ///                          "Value": "LS"
        ///                       },
        ///                       "SHORT_Description": {
        ///                          "Value": "辦公設備採購04_BPMTEST"
        ///                       },
        ///                       "NetAmount": {
        ///                          "currencyCode": "TWD",
        ///                          "Value": 123200
        ///                       },
        ///                       "NetUnitPrice": {
        ///                          "Amount": {
        ///                             "currencyCode": "TWD",
        ///                             "Value": 123200
        ///                          },
        ///                          "BaseQuantity": {
        ///                             "Value": 1
        ///                          },
        ///                          "BaseQuantityTypeCode": {
        ///                             "Value": "LS"
        ///                          }
        ///                       },
        ///                       "Product": {
        ///                          "CashDiscountDeductibleIndicator": false,
        ///                          "ProductCategoryIDKey": {
        ///                             "ProductCategoryInternalID": "FE"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "AccountingCodingBlockDistribution": {
        ///                          "AccountingCodingBlockAssignment": [
        ///                             {
        ///                                "AccountingCodingBlockTypeCode": {
        ///                                   "Value": "CC"
        ///                                },
        ///                                "CostCentreID": "MD10",
        ///                                "ActionCode": 0,
        ///                                "ActionCodeSpecified": true
        ///                             }
        ///                          ],
        ///                          "ActionCode": 0,
        ///                          "ActionCodeSpecified": true
        ///                       },
        ///                       "ProductTax": {
        ///                          "ProductTaxationCharacteristicsCode": {
        ///                             "listID": "",
        ///                             "Value": "P21"
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "PurchaseOrderReference": {
        ///                          "BusinessTransactionDocumentReference": {
        ///                             "ID": {
        ///                                "Value": "2926",
        ///                                "ItemID": "1"
        ///                             }
        ///                          },
        ///                          "actionCode": 0,
        ///                          "actionCodeSpecified": true
        ///                       },
        ///                       "actionCode": 0,
        ///                       "actionCodeSpecified": true
        ///                    }
        ///                 ],
        ///                 "APnote": "",
        ///                 "PRJ_NAM": "案件編號_FixedAsset_BPMTEST",
        ///                 "PjName": "",
        ///                 "REQUNIT": "MD20"
        ///              }
        ///           ]
        ///        },
        ///        "User": "string"
        ///     }
        /// </remarks>
        [ProducesResponseType(typeof(ApiOkResponse<SupplierInvoiceMaintainConfirmationBundle[]>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse<ErrorCodes>), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> FixedAssetsSupplierInvoice([FromBody] ProjectThirdPartySupplierInvoiceRequestRequest request, [FromHeader(Name = "API-Key")] string _, [FromHeader(Name = "Client-Credential-Option")] string? clientCredentialOption)
        {
            var endpointAddress = new EndpointAddress(_setting.CurrentValue.SAP.EndPoints.ManageSupplierInvoiceIn);

            var binding = new CustomBinding(
                new MtomMessageEncodingBindingElement(),
                new HttpsTransportBindingElement
                {
                    AuthenticationScheme = System.Net.AuthenticationSchemes.Basic
                });

            _logger.LogInformation("api: {actionName}, user: {user}, request: {request}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(request));
            var client = new ManageSupplierInvoiceInClient(binding, endpointAddress);
            var (userName, password) = CredentialHelper.GetCredentials(_setting, clientCredentialOption);

            client.ClientCredentials.UserName.UserName = userName;
            client.ClientCredentials.UserName.Password = password;

            var response = await client.MaintainBundleAsync(request.Payload);

            _logger.LogInformation("api: {actionName}, user: {user}, response: {response}", ControllerContext.ActionDescriptor.ActionName, request.User, JsonConvert.SerializeObject(response));
            if (response.SupplierInvoiceBundleMaintainConfirmation_sync?.SupplierInvoice == null)
            {
                return _myResponseFactory.CreateErrorResponse(ErrorCodes.BadRequestInvalidData, JsonConvert.SerializeObject(response.SupplierInvoiceBundleMaintainConfirmation_sync?.Log.Item.Select(x => x.Note)));
            }
            else
            {
                return _myResponseFactory.CreateOKResponse(response.SupplierInvoiceBundleMaintainConfirmation_sync.SupplierInvoice);
            }
        }

    }
}
