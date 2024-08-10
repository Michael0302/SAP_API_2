using InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInNS;

namespace SAP_WSDL_Library.Connected_Services.InventoryProcessingGoodsAndActivityConfirmationGoodsMovementInNS
{
    public class Sample
    {
        public static GoodsAndActivityConfirmationGoodsMoveGAC[] InternalLogisticsMaterialMovement = [
            new GoodsAndActivityConfirmationGoodsMoveGAC()
            {
                ExternalID = new BusinessTransactionDocumentID(){
                    Value = "FANG_BPMTEST_01"
                },
                SiteID = new LocationID(){
                    Value = "AT",
                },
                TransactionDateTime = Convert.ToDateTime("2024-05-26T06:35:19.457648Z"),
                TransactionDateTimeSpecified = true,
                InventoryChangeItemGoodsMovement = new InventoryChangeItemGoodsMovement[]{
                    new InventoryChangeItemGoodsMovement(){
                        ExternalItemID = "XXXXX-10",
                        MaterialInternalID = new ProductInternalID(){
                            Value = "EPKLEC0034"
                        },
                        OwnerPartyInternalID = new PartyInternalID(){
                            Value = "AT"
                        },
                        InventoryRestrictedUseIndicator = false,
                        SourceLogisticsAreaID = "CS01",
                        TargetLogisticsAreaID = "CS02",
                        InventoryItemChangeQuantity = new GoodsAndActivityConfirmationInventoryChangeInventoryChangeItemInventoryItemChangeQuantity(){
                            Quantity = new Quantity(){
                                unitCode = "EA",
                                Value = 3
                            },
                            QuantityTypeCode = new QuantityTypeCode(){
                                Value = "EA"
                            }
                        }
                    }
                },
            }
        ];
    }
}
