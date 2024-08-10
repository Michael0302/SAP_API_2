using ManagePurchaseRequestInNS;

namespace SAP_API.DTO.Request
{
    public class GeneralInventoryPurchaseRequestRequest
    {
        public required PurchaseRequestMessageManuallyCreate Payload { get; set; }
        public string? User { get; set; }
    }
}
