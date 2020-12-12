using Microservice2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.DataContext
{
    public class CompanyDbContext:DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {

        }
        DbSet<Company> Company { get; set; }
        DbSet<Ipo> Ipo { get; set; }
        DbSet<StockPrice> StockPrice { get; set; }
    }
}
