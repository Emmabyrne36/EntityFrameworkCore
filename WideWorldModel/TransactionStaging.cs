using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class TransactionStaging
    {
        public long TransactionStagingKey { get; set; }
        public DateTime? DateKey { get; set; }
        public int? CustomerKey { get; set; }
        public int? BillToCustomerKey { get; set; }
        public int? SupplierKey { get; set; }
        public int? TransactionTypeKey { get; set; }
        public int? PaymentMethodKey { get; set; }
        public int? WwiCustomerTransactionId { get; set; }
        public int? WwiSupplierTransactionId { get; set; }
        public int? WwiInvoiceId { get; set; }
        public int? WwiPurchaseOrderId { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public decimal? TotalExcludingTax { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? TotalIncludingTax { get; set; }
        public decimal? OutstandingBalance { get; set; }
        public bool? IsFinalized { get; set; }
        public int? WwiCustomerId { get; set; }
        public int? WwiBillToCustomerId { get; set; }
        public int? WwiSupplierId { get; set; }
        public int? WwiTransactionTypeId { get; set; }
        public int? WwiPaymentMethodId { get; set; }
        public DateTime? LastModifiedWhen { get; set; }
    }
}
