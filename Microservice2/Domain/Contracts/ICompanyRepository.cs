using Microservice2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Contracts
{
    public interface ICompanyRepository
    {
        public bool DeactivateCompany(string Company);
        public bool AddCompany(Company company);
        public bool DeleteCompany(string Company);
        public Company GetCompany(string Company);
        public IEnumerable<Company> GetAllCompanies();
        public bool UpdateCompnany(Company company);

        public IEnumerable<Company> GetAllCompaniesLike(string Name);
    }
}
