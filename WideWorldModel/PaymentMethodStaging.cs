using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class PaymentMethodStaging
    {
        public int PaymentMethodStagingKey { get; set; }
        public int WwiPaymentMethodId { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
