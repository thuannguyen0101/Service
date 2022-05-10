using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WcfService2.Models;

namespace WcfService2.Data
{
    public class Connection : DbContext
    { 
        public Connection() : base("Assignment") { }
        public DbSet<Employee> Employees { get; set; }
    }
}