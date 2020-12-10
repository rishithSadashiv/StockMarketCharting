using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice5.Entities;

namespace Microservice5.Domain.Contracts
{
    public interface IStockExchangeRepository
    {
        public IList<StockExchange> GetStockExchanges();

        public bool AddStockExchange(StockExchange stockExchange);

        public bool AddCompany(Company company);

        public IList<Company> GetCompaniesInStockExchange(string StockExchangeName);
    }
}
