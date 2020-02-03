using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Security.Models
{
    public class context : DbContext
    {
        public context()
            : base("name=DefaultConnection")
        {

        }
        public DbSet<User> tbl_user { get; set; }
        public DbSet<Product> tbl_Product { get; set; }
        
    }
}