using ManageSalesOrderInNS;
using QuerySalesOrderInNS;

namespace SAP_API.DTO.Request
{
    public class ProjectSalesOrderByElementsQueryRequest
    {
        public required SalesOrderByElementsQueryMessage_sync Payload { get; set; }
    }
}
