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
            context.Ipo.Add(ipo);
            int RowsAdded = context.SaveChanges();
            return RowsAdded > 0;
        }

        public bool DeleteIpo(int Id)
        {
            var Obj = context.Ipo.Find(Id);
            context.Ipo.Remove(Obj);
            int RowsDeleted = context.SaveChanges();
            return RowsDeleted > 0;
        }

        public IEnumerable<Ipo> GetAllIpos()
        {
            var query = from obj in context.Ipo
                        orderby obj.CompanyName
                        select obj;
            return query.ToList();
        }

        public IEnumerable<Ipo> GetIposOfCompany(string Company)
        {
            var Ipos = context.Ipo.Where(x => x.CompanyName.Equals(Company)).ToList();
            return Ipos;
        }

        public bool UpdateIpo(Ipo ipo)
        {
            context.Ipo.Update(ipo);
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }
    }
}
