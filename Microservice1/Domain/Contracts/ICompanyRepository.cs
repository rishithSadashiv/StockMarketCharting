using Microservice3.Dtos;
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

        bool AddCompany(Company company);

        bool UpdateCompany(Company company);

        Company GetCompany(int Id);

        bool UpdateCompanyDetailsFromMS2(Company2Dto dto);
    }
}
