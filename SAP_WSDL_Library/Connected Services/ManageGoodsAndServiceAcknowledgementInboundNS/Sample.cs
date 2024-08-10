using ManageGoodsAndServiceAcknowledgementInboundNS;

namespace SAP_WSDL_Library.Connected_Services.ManageGoodsAndServiceAcknowledgementInboundNS
{
    public class Sample
    {
        public static GSABundleMaintainRequestMessage_sync ProjectThirdPartyGoodsAndServiceAcknowledgement = new GSABundleMaintainRequestMessage_sync()
        {
            GoodsAndServiceAcknowledgement =
            [
                new GSAMaintainRequestBundle()
                {
                    actionCode = ActionCode.Item01,
                    actionCodeSpecified = true,
                    BusinessTransactionDocumentTypeCode = new BusinessTransactionDocumentTypeCode(){
                        Value = "282"
                    },
                    Date = "2024-04-10",
                    PostGSAIndicator = true,
                    PostGSAIndicatorSpecified = true,
                    DeliveryNoteReference = new GSAMaintainRequestBundleBTD(){
                        actionCode = ActionCode.Item01,
                        actionCodeSpecified = true,
                        ID = new BusinessTransactionDocumentID(){
                            Value = "ALICE_APITEST_004"
                        }
                    },
                    Item = [
                        new GSAMaintainRequestBundleItem(){
                            actionCode= ActionCode.Item01,
                            actionCodeSpecified = true,
                            BusinessTransactionDocumentTypeCode = new BusinessTransactionDocumentTypeCode(){
                                Value = "18"
                            },
                            Quantity = new Quantity(){
                                Value = 5,
                            },
                            QuantityTypeCode = new QuantityTypeCode(){
                                Value = "EA"
                            },
                            CustomerParty = new GSAMaintainRequestBundleItemParty(){
                                actionCode = ActionCode.Item01,
                                actionCodeSpecified = true,
                                PartyKey = new PartyKey(){
                                    PartyID = new PartyID(){
                                        Value = "E076"
                                    }
                                }
                            },
                            DeliveryPeriod = new UPPEROPEN_LOCALNORMALISED_DateTimePeriod(){
                                StartDateTime = new LOCALNORMALISED_DateTime(){
                                    Value = Convert.ToDateTime("2024-04-09T09:00:00Z"),
                                    timeZoneCode = "UTC+8"
                                },
                                EndDateTime = new LOCALNORMALISED_DateTime(){
                                    Value = Convert.ToDateTime("2024-04-15T18:00:00Z"),
                                    timeZoneCode = "UTC+8"
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
                                                Value = "AIN22032-B2-1"
                                            }
                                        },
                                        SalesOrderReference = new BusinessTransactionDocumentReference(){
                                            ID = new BusinessTransactionDocumentID(){
                                                Value = "339"
                                            },
                                            ItemID = "10"
                                        },
                                        EmployeeID = new EmployeeID() {
                                            Value = "E999916"
                                        }
                                    }
                                ]
                            },
                            PurchaseOrderReference = new GSAMaintainRequestBundleItemBusinessTransactionDocumentReference(){
                                ActionCode = ActionCode.Item01,
                                ActionCodeSpecified = true,
                                BusinessTransactionDocumentReference = new BusinessTransactionDocumentReference(){
                                    ID = new BusinessTransactionDocumentID(){
                                        Value = "2888"
                                    },
                                    TypeCode = new BusinessTransactionDocumentTypeCode() {
                                        Value = "001"
                                    },
                                    ItemID = "1",
                                    ItemTypeCode = "18"
                                }
                            }
                        }
                    ],
                }
            ] 
        };
    }
}
