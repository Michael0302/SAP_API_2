using CreateProjectPurchaseRequestNS;

namespace SAP_WSDL_Library.Connected_Services.CreateProjectPurchaseRequestNS
{
    public class Sample
    {
        public static ZProjectPurchaseRequestAPICreateRequestMessage_sync ProjectThirdPartyPurchaseRequestSample = new ZProjectPurchaseRequestAPICreateRequestMessage_sync()
        {
            ZProjectPurchaseRequestAPI = new ZProjectPurchaseRequestAPICreateRequest()
            {
                TypeCode = "1",
                ProjectID = new ProjectID()
                {
                    Value = "BPMTEST-2024042503"
                },
                TextCollection = new MaintenanceTextCollection()
                {
                    ActionCode = ActionCode.Item01,
                    ActionCodeSpecified = true,
                    Text = [
                        new MaintenanceTextCollectionText()
                        {
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
                                    Value = "BPM串接_專案採購請求_240514-01"
                                }
                            }
                        }
                    ]
                },
                Attachment = new MaintenanceAttachmentFolder()
                {
                    ActionCode = ActionCode.Item01,
                    ActionCodeSpecified = true,
                    Document = [
                        new MaintenanceAttachmentFolderDocument()
                        {
                            ActionCode = ActionCode.Item01,
                            ActionCodeSpecified = true,
                            VisibleIndicator = true,
                            VisibleIndicatorSpecified = true,
                            CategoryCode = "3",
                            TypeCode = new DocumentTypeCode(){
                                Value = "10001"
                            },
                            Name = "BPM串接_專案採購請求_240514-01",
                            AlternativeName = "Document Title_BPM串接_專案採購請求",
                            Description = new Description(){
                                Value = "BPM串接_專案採購請求_240514-01",
                                languageCode = "ZF"
                            },
                            ExternalLinkWebURI = "https://www.ampower.com.tw/"
                        }
                    ]
                },
                Item = [
                    new ZProjectPurchaseRequestAPICreateRequestItem(){
                        ProjectNo = "案件編號_BPM_24051401",
                        Specnote = "",
                        Material_Spec = "",
                        RequestedQuantity = new Quantity(){
                            unitCode = "LS",
                            Value = 3
                        },
                        TypeCode = "18",
                        DeliveryPeriod = new UPPEROPEN_LOCALNORMALISED_DateTimePeriod(){
                            StartDateTime = new LOCALNORMALISED_DateTime(){
                                timeZoneCode = "UTC+8",
                                Value = Convert.ToDateTime("2024-05-15T00:00:00Z")
                            },
                            EndDateTime = new LOCALNORMALISED_DateTime(){
                                timeZoneCode = "UTC+8",
                                Value = Convert.ToDateTime("2024-05-18T00:00:00Z")
                            }
                        },
                        ProductID = new ProductID(){
                            Value = "EXNE450007"
                        },
                        ProjectTaskID = new ProjectElementID(){
                            Value = "BPMTEST-2024042503-2"
                        },
                        Price = new Amount(){
                            currencyCode = "TWD",
                            Value = 1111
                        },
                        SupplierID = "B02009",
                        ShipToLocationID = new LocationID(){
                            Value = ""
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
                                        Text = new Text(){
                                            languageCode = "ZF",
                                            Value = "BPM串接_專案採購請求表身_240514-01"
                                        }
                                    }
                                }
                            ]
                        },
                        Attachment = new MaintenanceAttachmentFolder(){
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
                                    Name = "BPM串接_專案採購請求表身_240514-01",
                                    AlternativeName = "Document Title_BPM串接_專案採購請求表身",
                                    Description = new Description(){
                                        languageCode = "ZF",
                                        Value = "BPM串接_專案採購請求表身_240514-01"
                                    },
                                    ExternalLinkWebURI = "https://www.ampower.com.tw/"
                                }
                            ]
                        }
                    }
                ]
            }
        };
    }
}
