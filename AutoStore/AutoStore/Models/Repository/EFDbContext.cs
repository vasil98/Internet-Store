using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoStore.Models.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
    }
}
