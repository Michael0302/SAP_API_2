using ManageSiteLogisticsTaskInNS;

namespace SAP_API.DTO.Request
{
    public class ProcessIncomingDeliveryRequest
    {
        public required SiteLogisticsTaskMaintainRequestBundleMessage Payload { get; set; }
        public string? User { get; set; }
    }
}
