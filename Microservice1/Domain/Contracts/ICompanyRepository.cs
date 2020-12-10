using Microservice3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Domain.Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetCompaniesInSector(string sector);
        int getSectorPrice(string sector);
    }
}
