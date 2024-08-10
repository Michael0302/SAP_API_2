using QuerySalesOrderInNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP_WSDL_Library.Connected_Services.QuerySalesOrderInNS
{
    public class Sample
    {
        public static SalesOrderByElementsQueryMessage_sync SalesOrderByElementsQuery_sync = new SalesOrderByElementsQueryMessage_sync()
        {
            SalesOrderSelectionByElements = new SalesOrderByElementsQuerySelectionByElements()
            {
                SelectionByID = [ new SalesOrderByElementsQuerySelectionByID()
                {
                    InclusionExclusionCode = "I",
                    IntervalBoundaryTypeCode = "1",
                    LowerBoundaryID = new BusinessTransactionDocumentID(){
                        Value = "2485"
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
    }
}
