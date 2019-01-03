using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class EmployeeStaging
    {
        public int EmployeeStagingKey { get; set; }
        public int WwiEmployeeId { get; set; }
        public string Employee { get; set; }
        public string PreferredName { get; set; }
        public bool IsSalesperson { get; set; }
        public byte[] Photo { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
