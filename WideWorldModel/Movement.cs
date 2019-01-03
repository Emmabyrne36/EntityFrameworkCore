using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class Movement
    {
        public long MovementKey { get; set; }
        public DateTime DateKey { get; set; }
        public int StockItemKey { get; set; }
        public int? CustomerKey { get; set; }
        public int? SupplierKey { get; set; }
        public int TransactionTypeKey { get; set; }
        public int WwiStockItemTransactionId { get; set; }
        public int? WwiInvoiceId { get; set; }
        public int? WwiPurchaseOrderId { get; set; }
        public int Quantity { get; set; }
        public int LineageKey { get; set; }

        public virtual Customer CustomerKeyNavigation { get; set; }
        public virtual Date DateKeyNavigation { get; set; }
        public virtual StockItem StockItemKeyNavigation { get; set; }
        public virtual Supplier SupplierKeyNavigation { get; set; }
        public virtual TransactionType TransactionTypeKeyNavigation { get; set; }
    }
}
