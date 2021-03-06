﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GameSite.Models
{
    public class GameSiteContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GameSiteContext() : base("name=GameSiteContext")
        {
        }

        public System.Data.Entity.DbSet<GameSite.Models.Products> Products { get; set; }

        public System.Data.Entity.DbSet<GameSite.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<GameSite.Models.shoppingCart> shoppingCarts { get; set; }

        public System.Data.Entity.DbSet<GameSite.Models.Payment> Payments { get; set; }
    }
}
