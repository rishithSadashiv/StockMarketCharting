using Microservice3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Domain.Contracts
{
    public interface ISectorRepository
    {
        IEnumerable<Sector> getSectors(); //for drop-down list

        bool AddSector(Sector sector);
        
    }
}
