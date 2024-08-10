using ManagePurchaseOrderInNS;

namespace SAP_WSDL_Library.Connected_Services.ManagePurchaseOrderInNS
{
    public class Sample
    {
        public static PurchaseOrderBundleMaintainRequestMessage_sync ProjectThirdPartyPurchaseOrder = new PurchaseOrderBundleMaintainRequestMessage_sync
        {
            PurchaseOrderMaintainBundle =
            [
                new PurchaseOrderMaintainRequestBundle()
                {
                    actionCodeSpecified = true,
                    actionCode = ActionCode.Item01,
                    ItemListCompleteTransmissionIndicatorSpecified = true,
                    ItemListCompleteTransmissionIndicator = true,
                    ObjectNodeSenderTechnicalID = "1",
                    BusinessTransactionDocumentTypeCode = new BusinessTransactionDocumentTypeCode(){
                        Value = "001"
                    },
                    CurrencyCode = "TWD",
                    OrderPurchaseOrderActionIndicator = true,
                    OrderPurchaseOrderActionIndicatorSpecified = true,
                    FinishDeliveryPOActionIndicator = false,
                    FinishDeliveryPOActionIndicatorSpecified = true,
                    FinishInvoicePOActionIndicator = false,
                    FinishInvoicePOActionIndicatorSpecified = true,
                    BuyerParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCodeSpecified = true,
                        actionCode = ActionCode.Item01,
                        ObjectNodePartyTechnicalID = "2",
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "AT"
                            }
                        }
                    },
                    SellerParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCodeSpecified = true,
                        actionCode = ActionCode.Item01,
                        ObjectNodePartyTechnicalID = "3",
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "B02009"
                            }
                        }
                    },
                    EmployeeResponsibleParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCodeSpecified = true,
                        actionCode = ActionCode.Item01,
                        ObjectNodePartyTechnicalID = "4",
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "E999916"
                            }
                        }
                    },
                    ResponsiblePurchasingUnitParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCodeSpecified = true,
                        actionCode = ActionCode.Item01,
                        ObjectNodePartyTechnicalID = "5",
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "MD30"
                            }
                        }
                    },
                    AttachmentFolder = new MaintenanceAttachmentFolder(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        Document = [
                            new MaintenanceAttachmentFolderDocument(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                VisibleIndicator = true,
                                VisibleIndicatorSpecified = true,
                                CategoryCode = "3",
                                TypeCode = new DocumentTypeCode(){
                                    Value = "10001"
                                },
                                Name = "BPM串接_NAME_240502",
                                AlternativeName = "BPM串接表頭附件_Document Title文件標題_240502",
                                Description = new Description(){
                                    languageCode = "ZF",
                                    Value = "BPM串接表頭附件_comment留言_240502",
                                },
                                ExternalLinkWebURI = "",
                            }
                        ]
                    },
                    TextCollection = new MaintenanceTextCollection(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        Text = [
                            new MaintenanceTextCollectionText(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                TypeCode = new TextCollectionTextTypeCode(){
                                    Value = "10011"
                                },
                                LanguageCode = "ZF",
                                TextContent = new MaintenanceTextCollectionTextTextContent(){
                                    ActionCode = ActionCode.Item01,
                                    ActionCodeSpecified = true,
                                    Text = new Text(){
                                        languageCode = "ZF",
                                        Value = "BPM串接表頭註記_描述明細_240502",
                                    }
                                }
                            }
                        ]
                    },
                    DeliveryTerms = new PurchaseOrderMaintainRequestBundleDeliveryTerms(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        IncoTerms = new Incoterms(){
                            ClassificationCode = "EXW",
                            TransferLocationName = "TW"
                        }
                    },
                    CashDiscountTerms = new PurchaseOrderMaintenanceCashDiscountTerms(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        Code = new CashDiscountTermsCode(){
                            Value = "Z460"
                        }
                    },
                    Item = [
                        new PurchaseOrderMaintainRequestBundleItem(){
                            actionCodeSpecified = true,
                            actionCode = ActionCode.Item01,
                            ObjectNodeSenderTechnicalID = "6",
                            ItemID = "1",
                            BusinessTransactionDocumentItemTypeCode = "18",
                            Quantity = new Quantity(){
                                unitCode = "EA",
                                Value = 6
                            },
                            ListUnitPrice = new Price(){
                                Amount = new Amount(){
                                    currencyCode = "TWD",
                                    Value = 51000
                                },
                                BaseQuantity = new Quantity(){
                                    unitCode = "EA",
                                    Value = 1
                                },
                                BaseQuantityTypeCode = new QuantityTypeCode(){
                                    Value = "EA"
                                }
                            },
                            ThirdPartyDealIndicatorSpecified = true,
                            ThirdPartyDealIndicator = true,
                            FollowUpDelivery = new ProcurementDocumentItemFollowUpDelivery(){
                                RequirementCode = FollowUpBusinessTransactionDocumentRequirementCode.Item01,
                                RequirementCodeSpecified = true
                            },
                            FollowUpInvoice = new ProcurementDocumentItemFollowUpInvoice(){
                                RequirementCode = FollowUpBusinessTransactionDocumentRequirementCode.Item01,
                                RequirementCodeSpecified = true
                            },
                            ItemProduct = new PurchaseOrderMaintainRequestBundleItemProduct(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                CashDiscountDeductibleIndicator = false,
                                ProductKey = new ProductKey(){
                                    ProductTypeCode = "1",
                                    ProductIdentifierTypeCode = "1",
                                    ProductID = new ProductID(){
                                        Value = "PECNPR0001"
                                    }
                                }
                            },
                            PurchaserequestSAP = "2144",
                            DeliveryPeriod = new UPPEROPEN_LOCALNORMALISED_DateTimePeriod(){
                                StartDateTime = new LOCALNORMALISED_DateTime(){
                                    timeZoneCode = "UTC+8",
                                    Value = Convert.ToDateTime("2024-05-10T10:00:00Z"),
                                },
                            },
                            ShipToLocation = new PurchaseOrderMaintainRequestBundleItemLocation(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                ObjectNodePartyTechnicalID = "7",
                                LocationID = new LocationID(){
                                    Value = "AT"
                                }
                            },
                            ProductRecipientParty = new PurchaseOrderMaintainRequestBundleItemParty(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                ObjectNodePartyTechnicalID = "8",
                                PartyKey = new PartyKey(){
                                    PartyTypeCode = new BusinessObjectTypeCode(){
                                        Value = "147"
                                    },
                                    PartyID = new PartyID(){
                                        Value = "E210802"
                                    }
                                }
                            },
                            RequestorParty = new PurchaseOrderMaintainRequestBundleItemParty(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                ObjectNodePartyTechnicalID = "9",
                                PartyKey = new PartyKey(){
                                    PartyTypeCode = new BusinessObjectTypeCode(){
                                        Value = "147"
                                    },
                                    PartyID = new PartyID(){
                                        Value = "E210902"
                                    }
                                }
                            },
                            EndBuyerParty = new PurchaseOrderMaintainRequestBundleItemParty(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                ObjectNodePartyTechnicalID = "10",
                                PartyKey = new PartyKey(){
                                    PartyTypeCode = new BusinessObjectTypeCode(){
                                        Value = "159"
                                    },
                                    PartyID = new PartyID(){
                                        Value = "E001"
                                    }
                                }
                            },
                            ItemAccountingCodingBlockDistribution = new MaintenanceAccountingCodingBlockDistribution(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                CompanyID = "AT",
                                AccountingCodingBlockAssignment = [
                                    new MaintenanceAccountingCodingBlockDistributionAccountingCodingBlockAssignment(){
                                        ActionCode = ActionCode.Item01,
                                        ActionCodeSpecified = true,
                                        AccountingCodingBlockTypeCode = new AccountingCodingBlockTypeCode(){
                                            Value = "PRO"
                                        },
                                        ProjectTaskKey = new MaintenanceAccountingCodingBlockDistributionAccountingCodingBlockAssignmentProjectTaskKey(){
                                            TaskID = new ProjectElementID(){
                                                Value = "AIN23013-E5"
                                            }
                                        },
                                        SalesOrderReference = new BusinessTransactionDocumentReference(){
                                            ID = new BusinessTransactionDocumentID(){
                                                Value = "1601"
                                            },
                                            ItemID = "10"
                                        },
                                    }
                                ]
                            },
                            ItemAttachmentFolder = new MaintenanceAttachmentFolder(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                Document = [
                                    new MaintenanceAttachmentFolderDocument(){
                                        ActionCode = ActionCode.Item01,
                                        ActionCodeSpecified = true,
                                        VisibleIndicator = true,
                                        VisibleIndicatorSpecified = true,
                                        CategoryCode = "3",
                                        TypeCode = new DocumentTypeCode(){
                                            Value = "10001"
                                        },
                                        Name = "BPM串接_表身NAME_2400502",
                                        AlternativeName = "BPM串接表身附件_240502",
                                        Description = new Description(){
                                            languageCode = "ZF",
                                            Value = "BPM串接表身附件_comment留言_240502"
                                        },
                                        ExternalLinkWebURI = ""
                                    },
                                ]
                            },
                            ItemTextCollection = new MaintenanceTextCollection(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                Text = [
                                    new MaintenanceTextCollectionText(){
                                        ActionCode = ActionCode.Item01,
                                        ActionCodeSpecified = true,
                                        TypeCode = new TextCollectionTextTypeCode(){
                                            Value = "10011",
                                        },
                                        LanguageCode = "ZF",
                                        TextContent = new MaintenanceTextCollectionTextTextContent(){
                                            ActionCode = ActionCode.Item01,
                                            ActionCodeSpecified = true,
                                            Text = new Text(){
                                                languageCode = "ZF",
                                                Value = "BPM串接表身註記_描述明細_240502"
                                            }
                                        },
                                    }
                                ]
                            },
                            ItemTaxCalculation = new PurchaseOrderMaintainRequestTaxCalculationItem(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                CountryCode = "TW",
                                TaxationCharacteristicsCode = new ProductTaxationCharacteristicsCode(){
                                    listID = "TW",
                                    Value = "P21"
                                }
                            },
                        }
                    ],
                    PRJ_NAM = "BPM_POTEST_0502接續商品收貨",
                    PjName = "BPM_POTEST_0502"
                }
            ]
        };
        public static PurchaseOrderBundleMaintainRequestMessage_sync GeneralInventoryProcurement = new PurchaseOrderBundleMaintainRequestMessage_sync()
        {
            PurchaseOrderMaintainBundle = [
                new PurchaseOrderMaintainRequestBundle()
                {
                    actionCode = ActionCode.Item01,
                    actionCodeSpecified = true,
                    ItemListCompleteTransmissionIndicator = true,
                    ItemListCompleteTransmissionIndicatorSpecified = true,
                    BusinessTransactionDocumentTypeCode = new BusinessTransactionDocumentTypeCode(){
                        Value = "001"
                    },
                    CurrencyCode = "USD",
                    OrderPurchaseOrderActionIndicator = true,
                    OrderPurchaseOrderActionIndicatorSpecified = true,
                    FinishDeliveryPOActionIndicator = false,
                    FinishDeliveryPOActionIndicatorSpecified = true,
                    FinishInvoicePOActionIndicator = false,
                    FinishInvoicePOActionIndicatorSpecified = true,
                    BuyerParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCode = ActionCode.Item01,
                        actionCodeSpecified = true,
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "AT"
                            }
                        }
                    },
                    SellerParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCode = ActionCode.Item01,
                        actionCodeSpecified = true,
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "B02007"
                            }
                        }
                    },
                    EmployeeResponsibleParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCode = ActionCode.Item01,
                        actionCodeSpecified = true,
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "E999916"
                            }
                        }
                    },
                    ResponsiblePurchasingUnitParty = new PurchaseOrderMaintainRequestBundleParty(){
                        actionCode = ActionCode.Item01,
                        actionCodeSpecified = true,
                        PartyKey = new PartyKey(){
                            PartyID = new PartyID(){
                                Value = "MD30"
                            }
                        }
                    },
                    TextCollection = new MaintenanceTextCollection(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        Text = [
                            new MaintenanceTextCollectionText(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                TypeCode = new TextCollectionTextTypeCode(){
                                    Value = "10011"
                                },
                                LanguageCode = "ZF",
                                TextContent = new MaintenanceTextCollectionTextTextContent(){
                                    ActionCode = ActionCode.Item01,
                                    ActionCodeSpecified = true,
                                    Text = new Text(){
                                        languageCode = "ZF",
                                        Value = "BPM串接表頭註記_描述明細_240423"
                                    }
                                }
                            }
                        ]
                    },
                    AttachmentFolder = new MaintenanceAttachmentFolder(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        Document = [
                            new MaintenanceAttachmentFolderDocument(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                VisibleIndicator = true,
                                VisibleIndicatorSpecified = true,
                                CategoryCode = "3",
                                TypeCode = new DocumentTypeCode(){
                                    Value = "10001"
                                },
                                Name = "BPM串接_NAME_240423",
                                AlternativeName = "BPM串接表頭附件_Document Title文件標題_240423",
                                Description = new Description(){
                                    languageCode = "ZF",
                                    Value = "BPM串接表頭附件_comment留言_240423"
                                },
                                ExternalLinkWebURI = "https://www.ampower.com.tw/"
                            }
                        ]
                    },
                    DeliveryTerms = new PurchaseOrderMaintainRequestBundleDeliveryTerms(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        IncoTerms = new Incoterms(){
                            ClassificationCode = "EXW",
                            TransferLocationName = "TW"
                        }
                    },
                    CashDiscountTerms = new PurchaseOrderMaintenanceCashDiscountTerms(){
                        ActionCode = ActionCode.Item01,
                        ActionCodeSpecified = true,
                        Code = new CashDiscountTermsCode(){
                            Value = "Z420"
                        }
                    },
                    Item = [
                        new PurchaseOrderMaintainRequestBundleItem(){
                            actionCode = ActionCode.Item01,
                            actionCodeSpecified = true,
                            ItemID = "1",
                            BusinessTransactionDocumentItemTypeCode = "18",
                            Quantity = new Quantity(){
                                unitCode = "EA",
                                Value = 3
                            },
                            ListUnitPrice = new Price(){
                                Amount = new Amount(){
                                    currencyCode = "USD",
                                    Value = 24.41m
                                },
                                BaseQuantity = new Quantity(){
                                    Value = 1,
                                    unitCode = "EA"
                                },
                                BaseQuantityTypeCode = new QuantityTypeCode(){
                                    Value = "EA"
                                }
                            },
                            DeliveryPeriod = new UPPEROPEN_LOCALNORMALISED_DateTimePeriod(){
                                StartDateTime = new LOCALNORMALISED_DateTime(){
                                    timeZoneCode = "UTC+8",
                                    Value = Convert.ToDateTime("2024-04-26T10:00:00Z")
                                }
                            },
                            DirectMaterialIndicator = true,
                            DirectMaterialIndicatorSpecified = true,
                            FollowUpDelivery = new ProcurementDocumentItemFollowUpDelivery(){
                                RequirementCode = FollowUpBusinessTransactionDocumentRequirementCode.Item01,
                                RequirementCodeSpecified = true,
                            },
                            FollowUpInvoice = new ProcurementDocumentItemFollowUpInvoice(){
                                RequirementCode = FollowUpBusinessTransactionDocumentRequirementCode.Item01,
                                RequirementCodeSpecified = true,
                            },
                            ItemProduct = new PurchaseOrderMaintainRequestBundleItemProduct(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                CashDiscountDeductibleIndicator = false,
                                ProductKey = new ProductKey(){
                                    ProductTypeCode = "1",
                                    ProductIdentifierTypeCode = "1",
                                    ProductID = new ProductID(){
                                        Value = "FTKLLF0007"
                                    }
                                }
                            },
                            ShipToLocation = new PurchaseOrderMaintainRequestBundleItemLocation(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                LocationID = new LocationID(){
                                    Value = "AT"
                                }
                            },
                            RequestorParty = new PurchaseOrderMaintainRequestBundleItemParty(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                ObjectNodePartyTechnicalID = "1",
                                PartyKey = new PartyKey(){
                                    PartyTypeCode = new BusinessObjectTypeCode(){
                                        Value = "147"
                                    },
                                    PartyID = new PartyID(){
                                        Value = "E210902"
                                    }
                                }
                            },
                            ItemAttachmentFolder = new MaintenanceAttachmentFolder(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                Document = [
                                    new MaintenanceAttachmentFolderDocument(){
                                        ActionCode = ActionCode.Item01,
                                        ActionCodeSpecified = true,
                                        VisibleIndicator = true,
                                        VisibleIndicatorSpecified = true,
                                        CategoryCode = "3",
                                        TypeCode = new DocumentTypeCode(){
                                            Value = "10001"
                                        },
                                        Name = "BPM串接_表身NAME_240423",
                                        AlternativeName = "BPM串接表身附件_240423",
                                        Description = new Description(){
                                            languageCode = "ZF",
                                            Value = "BPM串接表身附件_comment留言_240423"
                                        },
                                        ExternalLinkWebURI = ""
                                    }
                                ]
                            },
                            ItemTextCollection = new MaintenanceTextCollection(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                Text = [
                                    new MaintenanceTextCollectionText(){
                                        ActionCode = ActionCode.Item01,
                                        ActionCodeSpecified = true,
                                        TypeCode = new TextCollectionTextTypeCode(){
                                            Value = "10011"
                                        },
                                        LanguageCode = "ZF",
                                        TextContent = new MaintenanceTextCollectionTextTextContent(){
                                            ActionCode = ActionCode.Item01,
                                            ActionCodeSpecified = true,
                                            Text = new Text(){
                                                languageCode = "ZF",
                                                Value = "BPM串接表身註記_描述明細_240423"
                                            }
                                        }
                                    }
                                ]
                            },
                            ItemTaxCalculation = new PurchaseOrderMaintainRequestTaxCalculationItem(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                CountryCode = "TW",
                                TaxationCharacteristicsCode = new ProductTaxationCharacteristicsCode(){
                                    listID = "TW",
                                    Value = "F28"
                                }
                            },
                        },
                        new PurchaseOrderMaintainRequestBundleItem(){
                            actionCode = ActionCode.Item01,
                            actionCodeSpecified = true,
                            ItemID = "2",
                            BusinessTransactionDocumentItemTypeCode = "18",
                            Quantity = new Quantity(){
                                Value = 5,
                                unitCode = "EA"
                            },
                            ListUnitPrice = new Price(){
                                Amount = new Amount(){
                                    currencyCode = "USD",
                                    Value = 262.09m
                                },
                                BaseQuantity = new Quantity(){
                                    Value = 1,
                                    unitCode = "EA"
                                },
                                BaseQuantityTypeCode = new QuantityTypeCode(){
                                    Value = "EA"
                                }
                            },
                            DeliveryPeriod = new UPPEROPEN_LOCALNORMALISED_DateTimePeriod(){
                                StartDateTime = new LOCALNORMALISED_DateTime(){
                                    timeZoneCode = "UTC+8",
                                    Value = Convert.ToDateTime("2024-04-26T10:00:00Z")
                                }
                            },
                            DirectMaterialIndicator = true,
                            DirectMaterialIndicatorSpecified = true,
                            FollowUpDelivery = new ProcurementDocumentItemFollowUpDelivery(){
                                RequirementCode = FollowUpBusinessTransactionDocumentRequirementCode.Item01,
                                RequirementCodeSpecified = true,
                            },
                            FollowUpInvoice = new ProcurementDocumentItemFollowUpInvoice(){
                                RequirementCode = FollowUpBusinessTransactionDocumentRequirementCode.Item01,
                                RequirementCodeSpecified = true,
                            },
                            ItemProduct = new PurchaseOrderMaintainRequestBundleItemProduct(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                CashDiscountDeductibleIndicator = false,
                                ProductKey = new ProductKey(){
                                    ProductTypeCode = "1",
                                    ProductIdentifierTypeCode = "1",
                                    ProductID = new ProductID(){
                                        Value = "PCKLOT0001"
                                    }
                                }
                            },
                            ShipToLocation = new PurchaseOrderMaintainRequestBundleItemLocation(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                LocationID = new LocationID(){
                                    Value = "AT"
                                }
                            },
                            RequestorParty = new PurchaseOrderMaintainRequestBundleItemParty(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                PartyKey = new PartyKey(){
                                    PartyTypeCode = new BusinessObjectTypeCode(){
                                        Value = "147"
                                    },
                                    PartyID = new PartyID(){
                                        Value = "E210902"
                                    }
                                }
                            },
                            ItemTaxCalculation = new PurchaseOrderMaintainRequestTaxCalculationItem(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                CountryCode = "TW",
                                TaxationCharacteristicsCode = new ProductTaxationCharacteristicsCode(){
                                    listID = "TW",
                                    Value = "F28"
                                }
                            },
                        }
                    ],
                    PRJ_NAM = "ALICE_API一般庫存採購06",
                    SU_Memo = "特別備註_API",
                    AppointedForwarder = "141",
                    CommissionOrder = "125",
                    ContactPerson = "Jamin Lee #1234",
                    Destination = "目的地_安葆台灣AT",
                    DiscountAmount = new Amount(){
                        currencyCode = "USD",
                        Value = 10
                    },
                    ExWork = "104",
                    Forwarder = "貨運代理商_SOETEK-TEST",
                    Freight = "137",
                    IfOthersplsspecify = "20240423-001",
                    Insurance = "保險號666666",
                    KOHLERQuotationRef = "121",
                    KOHLERShipTo = "118",
                    PartialShipmentAllow = "128",
                    PurchaseOrderNo = "PO#20240423-API001",
                    RequestedExFactoryDate = "2024-04-26",
                    ShipVia = "新加坡",
                    PjName = "ALICE_TEST_0423_06"
                }
            ]
        };
    }
}
