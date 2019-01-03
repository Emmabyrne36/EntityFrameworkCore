using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class StockItem
    {
        public StockItem()
        {
            Movement = new HashSet<Movement>();
            Order = new HashSet<Order>();
            Purchase = new HashSet<Purchase>();
            Sale = new HashSet<Sale>();
            StockHolding = new HashSet<StockHolding>();
        }

        public int StockItemKey { get; set; }
        public int WwiStockItemId { get; set; }
        public string StockItem1 { get; set; }
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
        public int LineageKey { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
        public virtual ICollection<StockHolding> StockHolding { get; set; }
    }
}
