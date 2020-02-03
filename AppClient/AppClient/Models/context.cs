using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppClient.Models
{
    public class context : DbContext
    {
        public context()
            : base("name=DefaultConnection")
        {

        }
        public DbSet<User> tbl_user { get; set; }
        public DbSet<Mail> tbl_Mail { get; set; }
        
    }
}