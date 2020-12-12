using Microservice2.DataContext;
using Microservice2.Domain.Contracts;
using Microservice2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly CompanyDbContext context;
        public CompanyRepository(CompanyDbContext ctx)
        {
            context = ctx;
        }


        public bool AddCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public bool DeactivateCompany(string Company)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCompany(string Company)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAllCompaniesLike(string Name)
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(string Company)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCompnany(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
