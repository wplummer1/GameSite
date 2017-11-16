using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSite.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Name { get; set;}
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Pcode { get; set; }
        public Double price { get; set; }
        public int stock { get; set; }
        public string ratings { get; set; }
        public string critiques { get; set; }
    }
}