using ManageSalesOrderInNS;

namespace SAP_API.DTO.Request
{
    public class MaterialSalesOrderRequest
    {
        public required SalesOrderMaintainRequestBundleMessage_sync Payload { get; set; }
        public string? User { get; set; }
    }
}
