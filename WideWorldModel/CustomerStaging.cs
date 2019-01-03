using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class CustomerStaging
    {
        public int CustomerStagingKey { get; set; }
        public int WwiCustomerId { get; set; }
        public string Customer { get; set; }
        public string BillToCustomer { get; set; }
        public string Category { get; set; }
        public string BuyingGroup { get; set; }
        public string PrimaryContact { get; set; }
        public string PostalCode { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
