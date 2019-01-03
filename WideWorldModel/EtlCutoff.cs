using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class EtlCutoff
    {
        public string TableName { get; set; }
        public DateTime CutoffTime { get; set; }
    }
}
