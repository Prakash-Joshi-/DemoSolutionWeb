using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CURDOperationFromFancybox.Models
{
    public class DbConnectionContext : DbContext
    {
        public DbConnectionContext():base("name=dbContext")
        { }
        public DbSet<StudentInformation> Students { get; set; }
    }
}