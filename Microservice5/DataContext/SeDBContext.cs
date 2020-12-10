using Microservice5.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice5.DataContext
{
    public class SeDBContext : DbContext
    {
        public SeDBContext(DbContextOptions<SeDBContext> Options) : base(Options)
        {

        }

        public DbSet<Company> Company{get;set;}
        public DbSet<StockExchange> StockExchange { get; set; }

    }
}
