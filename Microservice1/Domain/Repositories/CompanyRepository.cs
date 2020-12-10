using Microservice3.DataContext;
using Microservice3.Domain.Contracts;
using Microservice3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Domain.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly SectorDBContext context;
        public CompanyRepository(SectorDBContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Company> GetCompaniesInSector(string sector)
        {
            var query = from obj in context.Company
                        orderby obj.CompanyName
                        select obj;
            return query.ToList();
        }

        public int getSectorPrice(string sector)
        {
            var query = from obj in context.Company
                        orderby obj.CompanyName
                        where obj.Sector==sector
                        select obj;
            List<Company> companies = query.ToList();
            int cnt = companies.Count;
            if(cnt == 0)
            {
                return 0;
            }
            int sum = 0;
            foreach (Company c in companies)
            {
                sum += c.Turnover;
            }
            
            return sum/cnt;
        }
    }
}
