using CreateProjectNS;

namespace SAP_API.DTO.Request
{
    public class ProjectRequest
    {
        public required ZMaintainProjectAPICreateRequestMessage_sync Payload { get; set; }
        public string? User { get; set; }
    }
}
