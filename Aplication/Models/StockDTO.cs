namespace InventoryApplication.Models
{
    public class StockDTO
    {
        public string ItemId { get; set; }
        public string UbicacionId { get; set; }
        public string AlmacenId { get; set; }
        public decimal Cantidad { get; set; }
    }
}
