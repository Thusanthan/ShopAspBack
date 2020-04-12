using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAspBack.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {


        }

        public DbSet<StockDetail> StockDetails { get; set; }
        public DbSet<SellEntryDetail> sellEntryDetails { get; set; }


    }
}
