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
            try
            {
                StockExchange stockExchange = context.StockExchange.Single(s => s.StockExchangeName == company.StockExchangeName);
                company.stockExchange.Id = stockExchange.Id;
                context.Company.Add(company);
                int RowsAffected = context.SaveChanges();
                return RowsAffected > 0;
            }
            catch
            {
                throw new StockExchangeException("Stock exchange does not exist");
            }
        }

        public bool AddStockExchange(StockExchange stockExchange)
        {
            context.StockExchange.Add(stockExchange);
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }

        public IEnumerable<Company> GetCompaniesInStockExchange(string StockExchangeName)
        {
            StockExchange stockExchange = context.StockExchange
                                            .Include(se => se.companies)
                                            .Single(se => se.StockExchangeName == StockExchangeName);

            return stockExchange.companies;
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
