using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class Purchase
    {
        public long PurchaseKey { get; set; }
        public DateTime DateKey { get; set; }
        public int SupplierKey { get; set; }
        public int StockItemKey { get; set; }
        public int? WwiPurchaseOrderId { get; set; }
        public int OrderedOuters { get; set; }
        public int OrderedQuantity { get; set; }
        public int ReceivedOuters { get; set; }
        public string Package { get; set; }
        public bool IsOrderFinalized { get; set; }
        public int LineageKey { get; set; }

        public virtual Date DateKeyNavigation { get; set; }
        public virtual StockItem StockItemKeyNavigation { get; set; }
        public virtual Supplier SupplierKeyNavigation { get; set; }
    }
}
