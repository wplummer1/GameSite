using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameSite.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public string CardType { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpDate { get; set; }
        public int CCV { get; set; }
        
    }
}