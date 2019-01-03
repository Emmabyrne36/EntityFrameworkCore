using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class Employee
    {
        public Employee()
        {
            OrderPickerKeyNavigation = new HashSet<Order>();
            OrderSalespersonKeyNavigation = new HashSet<Order>();
            Sale = new HashSet<Sale>();
        }

        public int EmployeeKey { get; set; }
        public int WwiEmployeeId { get; set; }
        public string Employee1 { get; set; }
        public string PreferredName { get; set; }
        public bool IsSalesperson { get; set; }
        public byte[] Photo { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int LineageKey { get; set; }

        public virtual ICollection<Order> OrderPickerKeyNavigation { get; set; }
        public virtual ICollection<Order> OrderSalespersonKeyNavigation { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
