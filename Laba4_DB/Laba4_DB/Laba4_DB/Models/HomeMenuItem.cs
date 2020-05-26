using System;
using System.Collections.Generic;
using System.Text;

namespace Laba4_DB.Models
{
    public enum MenuItemType
    {
        Lab123,
        Lab4,
        Lab5,
        Lab6,
        About,
        Help
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
