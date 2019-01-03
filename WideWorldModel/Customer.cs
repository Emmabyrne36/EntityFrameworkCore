using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class Customer
    {
        public Customer()
        {
            Movement = new HashSet<Movement>();
            Order = new HashSet<Order>();
            SaleBillToCustomerKeyNavigation = new HashSet<Sale>();
            SaleCustomerKeyNavigation = new HashSet<Sale>();
            TransactionBillToCustomerKeyNavigation = new HashSet<Transaction>();
            TransactionCustomerKeyNavigation = new HashSet<Transaction>();
        }

        public int CustomerKey { get; set; }
        public int WwiCustomerId { get; set; }
        public string Customer1 { get; set; }
        public string BillToCustomer { get; set; }
        public string Category { get; set; }
        public string BuyingGroup { get; set; }
        public string PrimaryContact { get; set; }
        public string PostalCode { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Sale> SaleBillToCustomerKeyNavigation { get; set; }
        public virtual ICollection<Sale> SaleCustomerKeyNavigation { get; set; }
        public virtual ICollection<Transaction> TransactionBillToCustomerKeyNavigation { get; set; }
        public virtual ICollection<Transaction> TransactionCustomerKeyNavigation { get; set; }
    }
}
