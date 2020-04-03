using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAspBack.Models
{
    public class StockDetailContext : DbContext
    {

        public StockDetailContext(DbContextOptions<StockDetailContext> options) : base(options)
        {


        }

        public DbSet<StockDetail> Stockdetails { get; set; }


    }
}
