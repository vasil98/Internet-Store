using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStore.Models
{
    public class Auto
    {
        public int AutoId { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
    }
}
