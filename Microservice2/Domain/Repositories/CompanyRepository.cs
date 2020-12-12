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
            
            context.Company.Add(company);
            int RowsAdded = context.SaveChanges();
            return RowsAdded > 0;
        }

        public bool DeactivateCompany(string Company)
        {
            var Obj = GetCompany(Company);
            Obj.Active = false;
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }

        public bool DeleteCompany(string Company)
        {
            var Obj = GetCompany(Company);
            context.Company.Remove(Obj);
            int RowsDeleted = context.SaveChanges();
            return RowsDeleted > 0;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var query = from obj in context.Company
                        orderby obj.CompanyName
                        select obj;
            return query.ToList();
        }

        public IEnumerable<Company> GetAllCompaniesLike(string Name)
        {
            var companies1 = context.Company.Where(x => x.CompanyName.Contains(Name)).ToList();
            var companies2 = context.Company.Where(x => x.CompanyCode.Contains(Name)).ToList();
            return companies1.Concat(companies2).ToList();
        }

        public Company GetCompany(string Company)
        {
            return context.Company.Find(Company); ;
        }

        public bool UpdateCompnany(Company company)
        {
            context.Company.Update(company);
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }
    }
}
