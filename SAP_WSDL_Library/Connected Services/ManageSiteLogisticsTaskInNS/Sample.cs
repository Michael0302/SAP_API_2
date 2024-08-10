using ManageSiteLogisticsTaskInNS;

namespace SAP_WSDL_Library.Connected_Services.ManageSiteLogisticsTaskInNS
{
    public class Sample
    {
        public static SiteLogisticsTaskMaintainRequestBundleMessage ProcessIncomingDelivery = new SiteLogisticsTaskMaintainRequestBundleMessage()
        {
            BasicMessageHeader = new BusinessDocumentBasicMessageHeader()
            {
                ID = new BusinessDocumentMessageID()
                {
                    Value = "1"
                }
            },
            SiteLogisticsTask = [
                new SiteLogisticsTaskMaintainBundleRequest()
                {
                     SiteLogisticTaskID = new BusinessTransactionDocumentID(){
                         Value = "21",
                     },
                     SiteLogisticTaskUUID = new UUID(){
                         Value = "171d133d-f7be-1eef-80d7-21cdf62bf3ef"
                     },
                     ActualExecutionOn = Convert.ToDateTime("2024-04-25T10:33:00.1234567Z"),
                     ActualExecutionOnSpecified = true,
                     ReferenceObject = [
                          new SiteLogisticsTaskReferenceObjectManageBundle_Request(){
                              ReferenceObjectUUID = new UUID(){
                                  Value = "171d133d-f7be-1eef-80d7-21cdf62c13ef"
                              },
                              OperationActivity = [
                                  new SiteLogisticsLotOperationActivityManageBundle_Request(){
                                      OperationActivityUUID = new UUID(){
                                          Value = "171d133d-f7be-1eef-80d7-21cdf62ad3ef"
                                      },
                                      MaterialOutput = [
                                          new SLTMaterialOutputManageBundle_Request(){
                                              MaterialOutputUUID = new UUID(){
                                                  Value = "171d133d-f7be-1eef-80d7-21cdf62b33ef"
                                              },
                                              ProductID = new ProductID(){
                                                  Value = "PECNMT0017"
                                              },
                                              SourceLogisticsAreaIDPostSplit = "",
                                              TargetLogisticsAreaID = "CS01",
                                              ActualQuantity = new Quantity(){
                                                  unitCode = "EA",
                                                  Value = 2
                                              }
                                          }
                                      ]
                                  }
                              ]
                          }
                     ]
                }
            ]
        };
    }
}
