using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice3.Dtos;
using Microservice5.Entities;

namespace Microservice5.Domain.Contracts
{
    public interface IStockExchangeRepository
    {
        public IEnumerable<StockExchange> GetStockExchanges();

        public bool AddStockExchange(StockExchange stockExchange);

        public bool AddCompany(Company company);

        public IEnumerable<Company> GetAllCompanies();

        public IEnumerable<Company> GetCompaniesInStockExchange(string StockExchangeName);

        bool UpdateCompanyDetailsFromMS2(Company2Dto dto);

        public IEnumerable<Company> GetAllStockExchangesToWhichACompanyBelongs(string company);
    }
}
