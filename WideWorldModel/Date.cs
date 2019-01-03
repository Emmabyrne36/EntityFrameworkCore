using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class Date
    {
        public Date()
        {
            Movement = new HashSet<Movement>();
            OrderOrderDateKeyNavigation = new HashSet<Order>();
            OrderPickedDateKeyNavigation = new HashSet<Order>();
            Purchase = new HashSet<Purchase>();
            SaleDeliveryDateKeyNavigation = new HashSet<Sale>();
            SaleInvoiceDateKeyNavigation = new HashSet<Sale>();
            Transaction = new HashSet<Transaction>();
        }

        public DateTime Date1 { get; set; }
        public int DayNumber { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string ShortMonth { get; set; }
        public int CalendarMonthNumber { get; set; }
        public string CalendarMonthLabel { get; set; }
        public int CalendarYear { get; set; }
        public string CalendarYearLabel { get; set; }
        public int FiscalMonthNumber { get; set; }
        public string FiscalMonthLabel { get; set; }
        public int FiscalYear { get; set; }
        public string FiscalYearLabel { get; set; }
        public int IsoWeekNumber { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }
        public virtual ICollection<Order> OrderOrderDateKeyNavigation { get; set; }
        public virtual ICollection<Order> OrderPickedDateKeyNavigation { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
        public virtual ICollection<Sale> SaleDeliveryDateKeyNavigation { get; set; }
        public virtual ICollection<Sale> SaleInvoiceDateKeyNavigation { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
