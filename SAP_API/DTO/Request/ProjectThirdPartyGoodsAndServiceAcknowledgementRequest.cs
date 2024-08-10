using ManageGoodsAndServiceAcknowledgementInboundNS;

namespace SAP_API.DTO.Request
{
    public class ProjectThirdPartyGoodsAndServiceAcknowledgementRequest
    {
        public required GSABundleMaintainRequestMessage_sync Payload { get; set; }
        public string? User { get; set; }
    }
}
