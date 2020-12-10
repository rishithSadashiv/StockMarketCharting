using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice5.Domain.Contracts;
using Microservice5.Entities;

namespace Microservice5.Domain.Repository
{
    public class StockExchangeRepository : IStockExchangeRepository
    {
        public bool AddCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public bool AddStockExchange(StockExchange stockExchange)
        {
            throw new NotImplementedException();
        }

        public IList<Company> GetCompaniesInStockExchange(string StockExchangeName)
        {
            throw new NotImplementedException();
        }

        public IList<StockExchange> GetStockExchanges()
        {
            throw new NotImplementedException();
        }
    }
}
