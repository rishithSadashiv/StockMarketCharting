using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microservice3.Entities;
namespace Microservice3.DataContext
{
    public class SectorDBContext : DbContext
    {
        public SectorDBContext(DbContextOptions<SectorDBContext> options ) :base(options)
        {

        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Sector> Sector { get; set; }
    }
}
