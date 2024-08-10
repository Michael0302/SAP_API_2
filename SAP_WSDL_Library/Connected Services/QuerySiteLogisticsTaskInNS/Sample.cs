using QuerySiteLogisticsTaskInNS;

namespace SAP_WSDL_Library.Connected_Services.QuerySiteLogisticsTaskInNS
{
    public class Sample
    {
        public static SiteLogisticsTaskByElementsQueryMessage GetWarehouseTaskDetails = new SiteLogisticsTaskByElementsQueryMessage()
        {
            SiteLogisticsTaskSelectionByElements = new SiteLogisticsTaskSelectionByElements()
            {
                SelectionByReferenceDocumentID = [
                    new SiteLogisticsTaskSelectionByLotID()
                    {
                        InclusionExclusionCode = "I",
                        IntervalBoundaryTypeCode = "1",
                        LowerBoundaryReferenceDocumentID = new BusinessTransactionDocumentID(){
                            Value = "2911"
                        },
                        UpperBoundaryReferenceDocumentID = new BusinessTransactionDocumentID(){
                            Value = ""
                        }
                    }
                ],
            },
            ProcessingConditions = new QueryProcessingConditions()
            {
                QueryHitsMaximumNumberValue = 10,
                QueryHitsMaximumNumberValueSpecified = true,
                QueryHitsUnlimitedIndicator = false,
                LastReturnedObjectID = new ObjectID()
                {
                    Value = ""
                },
            }
        };
    }
}
