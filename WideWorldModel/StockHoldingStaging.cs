using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class StockHoldingStaging
    {
        public long StockHoldingStagingKey { get; set; }
        public int? StockItemKey { get; set; }
        public int? QuantityOnHand { get; set; }
        public string BinLocation { get; set; }
        public int? LastStocktakeQuantity { get; set; }
        public decimal? LastCostPrice { get; set; }
        public int? ReorderLevel { get; set; }
        public int? TargetStockLevel { get; set; }
        public int? WwiStockItemId { get; set; }
    }
}
