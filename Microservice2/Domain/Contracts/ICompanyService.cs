using Microservice2.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Contracts
{
    public interface ICompanyService
    {
        public bool DeactivateCompany(int Id);
        public bool AddCompany(CompanyDto company);
        public bool DeleteCompany(int Id);
        public CompanyDto GetCompany(int Id);
        public IEnumerable<CompanyDto> GetAllCompanies();
        public bool UpdateCompnany(CompanyDto company);

        public IEnumerable<CompanyDto> GetAllCompaniesLike(string Name);
    }
}
