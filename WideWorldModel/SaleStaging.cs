using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class SaleStaging
    {
        public long SaleStagingKey { get; set; }
        public int? CityKey { get; set; }
        public int? CustomerKey { get; set; }
        public int? BillToCustomerKey { get; set; }
        public int? StockItemKey { get; set; }
        public DateTime? InvoiceDateKey { get; set; }
        public DateTime? DeliveryDateKey { get; set; }
        public int? SalespersonKey { get; set; }
        public int? WwiInvoiceId { get; set; }
        public string Description { get; set; }
        public string Package { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TaxRate { get; set; }
        public decimal? TotalExcludingTax { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? Profit { get; set; }
        public decimal? TotalIncludingTax { get; set; }
        public int? TotalDryItems { get; set; }
        public int? TotalChillerItems { get; set; }
        public int? WwiCityId { get; set; }
        public int? WwiCustomerId { get; set; }
        public int? WwiBillToCustomerId { get; set; }
        public int? WwiStockItemId { get; set; }
        public int? WwiSalespersonId { get; set; }
        public DateTime? LastModifiedWhen { get; set; }
    }
}
