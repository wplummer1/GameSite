using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSite.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LName { get; set; }
        public string UName { get; set; }
        public string password { get; set; }
    }
}