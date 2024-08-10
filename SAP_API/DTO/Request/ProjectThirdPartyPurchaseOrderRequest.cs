using ManagePurchaseOrderInNS;

namespace SAP_API.DTO.Request
{
    public class ProjectThirdPartyPurchaseOrderRequest
    {
        public required PurchaseOrderBundleMaintainRequestMessage_sync Payload { get; set; }
        public string? User { get; set; }
    }
}
