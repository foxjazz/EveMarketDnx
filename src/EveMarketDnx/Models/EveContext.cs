using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace EveMarketDnx.Models
{
    public class EveContext : DbContext
    {
        public DbSet<EveItem> EveItems { get; set; }
        public DbSet<EveRegion> EveRegions { get; set; }
        public DbSet<EveBuy> buyOrders { get; set; }
        public DbSet<EveSell> sellOrders { get; set; }



    }
}
