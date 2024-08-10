using CreateProjectNS;
using CreateProjectStockOrderNS;

namespace SAP_API.DTO.Request
{
    public class ProjectStockOrderRequest
    {
        public required ZProjectStockOrderAPICreateRequestMessage_sync Payload { get; set; }
        public string? User { get; set; }
    }
}
