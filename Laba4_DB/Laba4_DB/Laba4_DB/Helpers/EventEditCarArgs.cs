using Laba4_DB.Models;
using SQLiteApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laba4_DB.Helpers
{
    public class EventEditCarArgs : EventArgs
    {
        public Car Car { get; set; }
    }
}
