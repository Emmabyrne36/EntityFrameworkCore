using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class Order
    {
        public long OrderKey { get; set; }
        public int CityKey { get; set; }
        public int CustomerKey { get; set; }
        public int StockItemKey { get; set; }
        public DateTime OrderDateKey { get; set; }
        public DateTime? PickedDateKey { get; set; }
        public int SalespersonKey { get; set; }
        public int? PickerKey { get; set; }
        public int WwiOrderId { get; set; }
        public int? WwiBackorderId { get; set; }
        public string Description { get; set; }
        public string Package { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TotalExcludingTax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalIncludingTax { get; set; }
        public int LineageKey { get; set; }

        public virtual City CityKeyNavigation { get; set; }
        public virtual Customer CustomerKeyNavigation { get; set; }
        public virtual Date OrderDateKeyNavigation { get; set; }
        public virtual Date PickedDateKeyNavigation { get; set; }
        public virtual Employee PickerKeyNavigation { get; set; }
        public virtual Employee SalespersonKeyNavigation { get; set; }
        public virtual StockItem StockItemKeyNavigation { get; set; }
    }
}
