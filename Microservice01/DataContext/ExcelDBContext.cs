using Microservice01.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice01.DataContext
{
    public class ExcelDBContext:DbContext
    {
        public ExcelDBContext(DbContextOptions<ExcelDBContext> options) : base(options)
        {

        }
        public DbSet<StockPrice> StockPrice { get; set; }
    }
}
