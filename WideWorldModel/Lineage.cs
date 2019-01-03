using System;
using System.Collections.Generic;

namespace CoreEF.WideWorldModel
{
    public partial class Lineage
    {
        public int LineageKey { get; set; }
        public DateTime DataLoadStarted { get; set; }
        public string TableName { get; set; }
        public DateTime? DataLoadCompleted { get; set; }
        public bool WasSuccessful { get; set; }
        public DateTime SourceSystemCutoffTime { get; set; }
    }
}
