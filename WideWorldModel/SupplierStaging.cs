using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class SupplierStaging
    {
        public int SupplierStagingKey { get; set; }
        public int WwiSupplierId { get; set; }
        public string Supplier { get; set; }
        public string Category { get; set; }
        public string PrimaryContact { get; set; }
        public string SupplierReference { get; set; }
        public int PaymentDays { get; set; }
        public string PostalCode { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
