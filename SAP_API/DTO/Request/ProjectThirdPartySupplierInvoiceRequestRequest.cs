using ManagePurchaseRequestInNS;
using ManageSupplierInvoiceInNS;

namespace SAP_API.DTO.Request
{
    public class ProjectThirdPartySupplierInvoiceRequestRequest
    {
        public required SupplierInvoiceBundleMaintainRequestMessage_sync Payload { get; set; }
        public string? User { get; set; }
    }
}
