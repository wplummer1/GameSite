using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSite.Models
{
    public class shoppingCart
    {
        public int ID { get; set; }
        public string UName { get; set; }
        public string Pname { get; set; }
        public string quantity { get; set; }
        private DateTime _addedDate = DateTime.MinValue;
        public DateTime addedDate
        {
            get
            {
                return (_addedDate == DateTime.MinValue) ? DateTime.Now : _addedDate;
            }
            set { _addedDate = value; }
        }
        //public DateTime addedDate { get; set; }
    }
}