namespace SAP_API.Configuration
{
    public class Settings
    {
        public required HashSet<string> ValidKeys { get; set; }
        public required SAP SAP { get; set; }
        public required QAD QAD { get; set; }
        public required Swagger Swagger { get; set; }
    }
    public class Swagger
    {
        public required string DocumentFilter { get; set; }
    }
    public class SAPEndPoints
    {
        public required string CreateProject { get; set; }
        public required string QuerySiteLogisticsTaskIn { get; set; }
        public required string ManageSiteLogisticsTaskIn { get; set; }
        public required string CreateProjectPurchaseRequest { get; set; }
        public required string InventoryProcessingGoodsAndActivityConfirmationGoodsConfirmationIn { get; set; }
        public required string InventoryProcessingGoodsAndActivityConfirmationGoodsMovementIn { get; set; }
        public required string ManageGoodsAndServiceAcknowledgementInbound { get; set; }
        public required string ManagePurchaseOrderIn { get; set; }
        public required string ManagePurchaseRequestIn { get; set; }
        public required string ManageSalesOrderIn { get; set; }
        public required string ManageSupplierInvoiceIn { get; set; }
        public required string QuerySalesOrderIn { get; set; }
        public required string CreateProjectStockOrder { get; set; }
    }
    public class ClientCredentials
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
    public class SAP
    {
        public required SAPEndPoints EndPoints { get; set; }
        public required ClientCredentials ClientCredentials { get; set; }
        public required ClientCredentials ClientCredentials2 { get; set; }
    }
    public class QAD
    {
        public required QADEndPoints EndPoints { get; set; }
    }
    public class QADEndPoints
    {
        public required string MaintainGeneralizedCode { get; set; }
    }
}