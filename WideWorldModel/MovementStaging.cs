using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class MovementStaging
    {
        public long MovementStagingKey { get; set; }
        public DateTime? DateKey { get; set; }
        public int? StockItemKey { get; set; }
        public int? CustomerKey { get; set; }
        public int? SupplierKey { get; set; }
        public int? TransactionTypeKey { get; set; }
        public int? WwiStockItemTransactionId { get; set; }
        public int? WwiInvoiceId { get; set; }
        public int? WwiPurchaseOrderId { get; set; }
        public int? Quantity { get; set; }
        public int? WwiStockItemId { get; set; }
        public int? WwiCustomerId { get; set; }
        public int? WwiSupplierId { get; set; }
        public int? WwiTransactionTypeId { get; set; }
        public DateTime? LastModifedWhen { get; set; }
    }
}
