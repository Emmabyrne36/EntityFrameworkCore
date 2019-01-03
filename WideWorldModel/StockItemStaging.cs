using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class StockItemStaging
    {
        public int StockItemStagingKey { get; set; }
        public int WwiStockItemId { get; set; }
        public string StockItem { get; set; }
        public string Color { get; set; }
        public string SellingPackage { get; set; }
        public string BuyingPackage { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public int LeadTimeDays { get; set; }
        public int QuantityPerOuter { get; set; }
        public bool IsChillerStock { get; set; }
        public string Barcode { get; set; }
        public decimal TaxRate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? RecommendedRetailPrice { get; set; }
        public decimal TypicalWeightPerUnit { get; set; }
        public byte[] Photo { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
