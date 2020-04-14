using OxyPlot;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laba3.Models
{
    public class OxyPlotItem
    {
        public string Label { get; set; }

        public double Value { get; set; }

        public OxyColor Color { get; set; }

        public DataPoint X { get; set; }
    }
}
