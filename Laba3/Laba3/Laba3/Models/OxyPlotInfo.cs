using System;
using System.Collections.Generic;
using System.Text;

namespace Laba3.Models
{
    public class OxyPlotInfo
    {
        public string Info { get; set; }
        public ICollection<OxyPlotItem> Items { get; set; }
    }
}
