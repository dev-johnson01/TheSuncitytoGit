using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Suncity.Models
{
    public class SuncityDatabase: DbContext
    {
        public SuncityDatabase() : base("CustomerDC") { }
        public DbSet <Customer> Customers { get; set; }
        public DbSet <Agent>  Agents{ get; set; }

    }
}