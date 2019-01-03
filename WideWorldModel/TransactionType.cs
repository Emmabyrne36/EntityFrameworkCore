using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            Movement = new HashSet<Movement>();
            Transaction = new HashSet<Transaction>();
        }

        public int TransactionTypeKey { get; set; }
        public int WwiTransactionTypeId { get; set; }
        public string TransactionType1 { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
