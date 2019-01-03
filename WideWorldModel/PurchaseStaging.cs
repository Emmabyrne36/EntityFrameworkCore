using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class PurchaseStaging
    {
        public long PurchaseStagingKey { get; set; }
        public DateTime? DateKey { get; set; }
        public int? SupplierKey { get; set; }
        public int? StockItemKey { get; set; }
        public int? WwiPurchaseOrderId { get; set; }
        public int? OrderedOuters { get; set; }
        public int? OrderedQuantity { get; set; }
        public int? ReceivedOuters { get; set; }
        public string Package { get; set; }
        public bool? IsOrderFinalized { get; set; }
        public int? WwiSupplierId { get; set; }
        public int? WwiStockItemId { get; set; }
        public DateTime? LastModifiedWhen { get; set; }
    }
}
