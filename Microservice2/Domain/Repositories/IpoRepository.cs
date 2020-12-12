using Microservice2.DataContext;
using Microservice2.Domain.Contracts;
using Microservice2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Repositories
{
    public class IpoRepository : IIpoRepository
    {
        readonly CompanyDbContext context;
        public IpoRepository(CompanyDbContext ctx)
        {
            context = ctx;
        }
        public bool AddIpo(Ipo ipo)
        {
            throw new NotImplementedException();
        }

        public bool DeleteIpo(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ipo> GetAllIpos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ipo> GetIposOfCompany(string Company)
        {
            throw new NotImplementedException();
        }

        public bool UpdateIpo(Ipo ipo)
        {
            throw new NotImplementedException();
        }
    }
}
