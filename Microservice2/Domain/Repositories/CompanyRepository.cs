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
        readonly CompanyDbContext context1;
        public CompanyRepository(CompanyDbContext ctx)
        {
            context1 = ctx;
        }


        public bool AddCompany(Company company)
        {

            context1.Company.Add(company);
            int RowsAdded = context1.SaveChanges();
            return RowsAdded > 0;
        }

        public bool DeactivateCompany(int Id)
        {
            try
            {
                var Obj = GetCompany(Id);
                Obj.Active = !Obj.Active;
                int RowsAffected = context1.SaveChanges();
                return RowsAffected > 0;
            }catch(NullReferenceException)
            {
                throw new Exception("Invalid ID");
            }
        }

        public bool DeleteCompany(int Id)
        {
            try { 
            var Obj = GetCompany(Id);
            context1.Company.Remove(Obj);
            int RowsDeleted = context1.SaveChanges();
            return RowsDeleted > 0;
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Invalid ID");
            }
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var query = from obj in context1.Company
                        orderby obj.CompanyName
                        select obj;
            return query.ToList();
        }

        public IEnumerable<Company> GetAllCompaniesLike(string Name)
        {
            var companies1 = context1.Company.Where(x => x.CompanyName.Contains(Name)).ToList();
            var companies2 = context1.Company.Where(x => x.CompanyCode.Contains(Name)).ToList();
            return companies1.Concat(companies2).ToList();
        }

        public Company GetCompany(int Id)
        {
            return context1.Company.Find(Id); 
        }

        public bool UpdateCompnany(Company company)
        {
            context1.Company.Update(company);
            int RowsAffected = context1.SaveChanges();
            return RowsAffected > 0;
        }
    }
}
