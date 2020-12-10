using Microservice3.DataContext;
using Microservice3.Domain.Contracts;
using Microservice3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Domain.Repositories
{
    public class SectorRepository : ISectorRepository
    {

        readonly SectorDBContext context;
        public SectorRepository(SectorDBContext ctx)
        {
            context = ctx;
        }

        public bool AddSector(Sector sector)
        {
            context.Sector.Add(sector);
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }

        public IEnumerable<Sector> getSectors()
        {
            var query = from obj in context.Sector
                        orderby obj.SectorName
                        select obj;
            return query.ToList();
        }
    }
}
