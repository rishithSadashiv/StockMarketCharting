using Microservice3.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Domain.Contracts
{
    public interface ISectorService
    {
        IEnumerable<SectorDto> getSectors(); //for drop-down list

    }
}
