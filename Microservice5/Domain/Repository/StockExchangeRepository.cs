using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice5.DataContext;
using Microservice5.Domain.Contracts;
using Microservice5.Entities;
using Microservice5.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Microservice5.Domain.Repository
{
    public class StockExchangeRepository : IStockExchangeRepository
    {
        readonly SeDBContext context;
        public StockExchangeRepository(SeDBContext context)
        {
            this.context = context;
        }

        public bool AddCompany(Company company)
        {
            
                context.Company.Add(company);
                int RowsAdded = context.SaveChanges();
                return RowsAdded > 0;

            
        }

        public bool AddStockExchange(StockExchange stockExchange)
        {
            context.StockExchange.Add(stockExchange);
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }

        public IEnumerable<Company> GetCompaniesInStockExchange(string StockExchangeName)
        {
            var query = from obj in context.Company
                        orderby obj.CompanyName
                        where obj.StockExchangeName == StockExchangeName
                        select obj;
            return query.ToList();


            
        }

        public IEnumerable<StockExchange> GetStockExchanges()
        {
            var query = from obj in context.StockExchange
                        orderby obj.StockExchangeName
                        select obj;
            return query.ToList();
        }
    }
}
