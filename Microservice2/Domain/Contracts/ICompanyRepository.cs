using Microservice2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Contracts
{
    public interface ICompanyRepository
    {
        public bool DeactivateCompany(int Id);
        public bool AddCompany(Company company);
        public bool DeleteCompany(int Id);
        public Company GetCompany(int Id);
        public IEnumerable<Company> GetAllCompanies();
        public bool UpdateCompnany(Company company);

        public IEnumerable<Company> GetAllCompaniesLike(string Name);
    }
}
