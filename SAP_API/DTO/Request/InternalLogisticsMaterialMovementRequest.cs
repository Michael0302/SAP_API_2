using InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInNS;

namespace SAP_API.DTO.Request
{
    public class InternalLogisticsMaterialMovementRequest
    {
        public required GoodsAndActivityConfirmationGoodsMoveGAC[] Payload { get; set; }
        public string? User { get; set; }
    }
}
