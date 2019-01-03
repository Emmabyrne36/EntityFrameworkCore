using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class Supplier
    {
        public Supplier()
        {
            Movement = new HashSet<Movement>();
            Purchase = new HashSet<Purchase>();
            Transaction = new HashSet<Transaction>();
        }

        public int SupplierKey { get; set; }
        public int WwiSupplierId { get; set; }
        public string Supplier1 { get; set; }
        public string Category { get; set; }
        public string PrimaryContact { get; set; }
        public string SupplierReference { get; set; }
        public int PaymentDays { get; set; }
        public string PostalCode { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
