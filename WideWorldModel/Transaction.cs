using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class Transaction
    {
        public long TransactionKey { get; set; }
        public DateTime DateKey { get; set; }
        public int? CustomerKey { get; set; }
        public int? BillToCustomerKey { get; set; }
        public int? SupplierKey { get; set; }
        public int TransactionTypeKey { get; set; }
        public int? PaymentMethodKey { get; set; }
        public int? WwiCustomerTransactionId { get; set; }
        public int? WwiSupplierTransactionId { get; set; }
        public int? WwiInvoiceId { get; set; }
        public int? WwiPurchaseOrderId { get; set; }
        public string SupplierInvoiceNumber { get; set; }
        public decimal TotalExcludingTax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalIncludingTax { get; set; }
        public decimal OutstandingBalance { get; set; }
        public bool IsFinalized { get; set; }
        public int LineageKey { get; set; }

        public virtual Customer BillToCustomerKeyNavigation { get; set; }
        public virtual Customer CustomerKeyNavigation { get; set; }
        public virtual Date DateKeyNavigation { get; set; }
        public virtual PaymentMethod PaymentMethodKeyNavigation { get; set; }
        public virtual Supplier SupplierKeyNavigation { get; set; }
        public virtual TransactionType TransactionTypeKeyNavigation { get; set; }
    }
}
