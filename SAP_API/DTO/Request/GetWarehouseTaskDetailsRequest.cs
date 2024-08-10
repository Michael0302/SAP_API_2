using QuerySiteLogisticsTaskInNS;

namespace SAP_API.DTO.Request
{
    public class GetWarehouseTaskDetailsRequest
    {
        public required SiteLogisticsTaskByElementsQueryMessage Payload { get; set; }
        public string? User { get; set; }
    }
}
