using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int PaymentMethodKey { get; set; }
        public int WwiPaymentMethodId { get; set; }
        public string PaymentMethod1 { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
