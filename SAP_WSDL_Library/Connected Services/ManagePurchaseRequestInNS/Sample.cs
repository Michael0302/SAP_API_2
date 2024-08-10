
using ManagePurchaseRequestInNS;

namespace SAP_WSDL_Library.Connected_Services.ManagePurchaseRequestInNS
{
    public class Sample
    {
        public static PurchaseRequestMessageManuallyCreate GeneralInventoryPurchaseRequestSample = new PurchaseRequestMessageManuallyCreate()
        {
            PurchaseRequestMaintainBundle =
                [
                    new ManuallyPurchaseRequest()
                    {
                        actionCodeSpecified = true,
                        actionCode = ActionCode.Item01,
                        Item =
                        [
                            new PurchaseRequestItemManually()
                            {
                                actionCodeSpecified = true,
                                actionCode = ActionCode.Item01,
                                ItemID = "1",
                                ProductKeyItem = new PurchaseRequestMaintainRequestProductKeyItem(){
                                    ProductTypeCode = "1",
                                    ProductIdentifierTypeCode = "1",
                                    ProductID = new ProductID(){
                                        Value = "PECNMT0012"
                                    }
                                },
                                TypeCode = "18",
                                Quantity = new Quantity(){
                                    Value = 6,
                                    unitCode = "EA"
                                },
                                DeliveryPeriod = new UPPEROPEN_LOCALNORMALISED_DateTimePeriod(){
                                    StartDateTime = new LOCALNORMALISED_DateTime(){
                                        Value = Convert.ToDateTime("2024-04-20T12:00:00.1234567Z"),
                                        timeZoneCode = "UTC+8"
                                    }
                                },
                                ShipToLocationID = new LocationID(){
                                    Value = "AT"
                                },
                                ListUnitPrice = new Price(){
                                    Amount = new Amount(){
                                        Value = 1500,
                                        currencyCode = "TWD"
                                    },
                                    BaseQuantity = new Quantity(){
                                        Value = 1,
                                        unitCode = "EA"
                                    }
                                },
                                CompanyIDParty = new PurchaseRequestMaintainRequestBundleItemParty(){
                                    actionCodeSpecified = true,
                                    actionCode = ActionCode.Item01,
                                    PartyID = new PartyID(){
                                        Value = "AT"
                                    }
                                },
                                RequesterIDParty = new PurchaseRequestMaintainRequestBundleItemParty(){
                                    actionCodeSpecified = true,
                                    actionCode = ActionCode.Item01,
                                    PartyID = new PartyID(){
                                        Value = "E999967"
                                    }
                                },
                                SupplierIDParty = new PurchaseRequestMaintainRequestBundleItemParty(){
                                    actionCodeSpecified = true,
                                    actionCode = ActionCode.Item01,
                                    PartyID = new PartyID(){
                                        Value = "A01038"
                                    }
                                },
                                directMaterialIndicatorSpecified = true,
                                directMaterialIndicator = true,
                                Project_No = "ALICE-TESTAPI",
                                specnote = "產品規格_ALICE"
                            }
                        ],
                        PURCREQUNIT = "AT-CS00",
                    }
                ]
        };
        public static PurchaseRequestMessageManuallyCreate ProjectThirdPartyPurchaseRequestSample = new PurchaseRequestMessageManuallyCreate()
        {
            PurchaseRequestMaintainBundle =
                [
                    new ManuallyPurchaseRequest()
                    {
                        actionCodeSpecified = true,
                        actionCode = ActionCode.Item01,
                        Item =
                        [
                            new PurchaseRequestItemManually()
                            {
                                actionCodeSpecified = true,
                                actionCode = ActionCode.Item01,
                                ItemID = "1",
                                ProductKeyItem = new PurchaseRequestMaintainRequestProductKeyItem(){
                                    ProductTypeCode = "1",
                                    ProductIdentifierTypeCode = "1",
                                    ProductID = new ProductID(){
                                        Value = "PECNPR0001"
                                    }
                                },
                                TypeCode = "18",
                                thirdPartyIndicatorSpecified = true,
                                thirdPartyIndicator = true,
                                Quantity = new Quantity(){
                                    Value = 12,
                                    unitCode = "EA"
                                },
                                DeliveryPeriod = new UPPEROPEN_LOCALNORMALISED_DateTimePeriod(){
                                    StartDateTime = new LOCALNORMALISED_DateTime(){
                                        Value = Convert.ToDateTime("2024-04-01T12:00:00.1234567Z"),
                                        timeZoneCode = "UTC+8"
                                    },
                                    EndDateTime = new LOCALNORMALISED_DateTime(){
                                        Value = Convert.ToDateTime("2024-04-10T12:00:00.1234567Z"),
                                        timeZoneCode = "UTC+8"
                                    }
                                },
                                ListUnitPrice = new Price(){
                                    Amount = new Amount(){
                                        Value = 51000,
                                        currencyCode = "TWD"
                                    },
                                    BaseQuantity = new Quantity(){
                                        Value = 1,
                                        unitCode = "EA"
                                    }
                                },
                                CompanyIDParty = new PurchaseRequestMaintainRequestBundleItemParty(){
                                    actionCodeSpecified = true,
                                    actionCode = ActionCode.Item01,
                                    PartyID = new PartyID(){
                                        Value = "AT"
                                    }
                                },
                                RequesterIDParty = new PurchaseRequestMaintainRequestBundleItemParty(){
                                    actionCodeSpecified = true,
                                    actionCode = ActionCode.Item01,
                                    PartyID = new PartyID(){
                                        Value = "E210902"
                                    }
                                },
                                SupplierIDParty = new PurchaseRequestMaintainRequestBundleItemParty(){
                                    actionCodeSpecified = true,
                                    actionCode = ActionCode.Item01,
                                    PartyID = new PartyID(){
                                        Value = "B02009"
                                    }
                                },
                                ItemAccountAssignmentDistribution = new MaintenanceAccountingCodingBlockDistribution(){
                                    AccountingCodingBlockAssignmentListCompleteTransmissionIndicatorSpecified = true,
                                    AccountingCodingBlockAssignmentListCompleteTransmissionIndicator = true,
                                    ActionCodeSpecified = true,
                                    ActionCode = ActionCode.Item01,
                                    AccountingCodingBlockAssignment = [
                                        new MaintenanceAccountingCodingBlockDistributionAccountingCodingBlockAssignment(){
                                            ActionCodeSpecified = true,
                                            ActionCode = ActionCode.Item01,
                                            AccountingCodingBlockTypeCode = new AccountingCodingBlockTypeCode(){
                                                Value = "PRO"
                                            },
                                            ProjectTaskKey = new MaintenanceAccountingCodingBlockDistributionAccountingCodingBlockAssignmentProjectTaskKey(){
                                                TaskID = new ProjectElementID(){
                                                    Value = "AIN23013-E5"
                                                }
                                            },
                                            ProjectReference = new ProjectReference(){
                                                ProjectID = new ProjectID(){
                                                    Value = "AIN23013"
                                                },
                                                ProjectElementID = new ProjectElementID(){
                                                    Value = "AIN23013-E5"
                                                },
                                            }
                                        }
                                    ]
                                },
                            }
                        ],
                        TextCollection = new MaintenanceTextCollection(){
                            ActionCodeSpecified = true,
                            ActionCode = ActionCode.Item01,
                            Text = [
                                new MaintenanceTextCollectionText(){
                                    ActionCodeSpecified = true,
                                    ActionCode = ActionCode.Item01,
                                    TypeCode = new TextCollectionTextTypeCode(){
                                        Value = "10011"
                                    },
                                    LanguageCode = "ZF",
                                    TextContent = new MaintenanceTextCollectionTextTextContent(){
                                        ActionCodeSpecified = true,
                                        ActionCode = ActionCode.Item01,
                                        Text = new Text(){
                                            languageCode = "ZF",
                                            Value = "BPM串接_測試_專案請購_003"
                                        }
                                    }
                                }
                            ]
                        },
                        AttachmentFolder = new MaintenanceAttachmentFolder(){
                            ActionCodeSpecified = true,
                            ActionCode = ActionCode.Item01,
                            Document = [
                                new MaintenanceAttachmentFolderDocument(){
                                    ActionCodeSpecified = true,
                                    ActionCode = ActionCode.Item01,
                                    Name = "BPM_測試_請購003",
                                    VisibleIndicatorSpecified = true,
                                    VisibleIndicator = true,
                                    CategoryCode = "3",
                                    Description = new Description(){
                                        languageCode = "ZF",
                                        Value = "BPM串接_附件測試_003"
                                    },
                                    ExternalLinkWebURI = "https://soetw-my.sharepoint.com/:x:/g/personal/alicefang_soetek_com_tw/Ecp2LhispUpAjzb7_Ytpok0BbW9GkslJ6Qm0L1krWUzcGQ?e=AgjfJq"
                                }
                            ]
                        }
                    }
                ]
        };
    }
}
