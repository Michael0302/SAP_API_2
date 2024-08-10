using QuerySiteLogisticsTaskInNS;

namespace SAP_API.DTO.Response
{
    public class GetWarehouseTaskDetailsResponse
    {
        public ResponseProcessingConditions? ProcessingConditions { get; set; }
        public SiteLogisticsTaskByElementsResponse_sync[]? SiteLogisticsTask { get; set; }
    }
}
