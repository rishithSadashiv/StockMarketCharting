using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice5.Dtos;

namespace Microservice5.Domain.Contracts
{
    interface IStockExchangeService
    {
        public IList<StockExchangeDto> GetStockExchanges();

        public bool AddStockExchange(StockExchangeDto stockExchange);

        public bool AddCompany(CompanyDto company);

        public IList<CompanyDto> GetCompaniesInStockExchange(string StockExchangeName);
    }
}
