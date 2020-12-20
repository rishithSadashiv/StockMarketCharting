using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice3.Dtos;
using Microservice5.Dtos;

namespace Microservice5.Domain.Contracts
{
    public interface IStockExchangeService
    {
        public IEnumerable<StockExchangeDto> GetStockExchanges();

        public bool AddStockExchange(StockExchangeDto stockExchange);

        public bool AddCompany(CompanyDto company);

        public IEnumerable<CompanyDto> GetCompaniesInStockExchange(string StockExchangeName);

        public IEnumerable<CompanyDto> GetAllCompanies();

        bool UpdateCompanyDetailsFromMS2(Company2Dto dto);

        public IEnumerable<CompanyDto> GetAllStockExchangesToWhichACompanyBelongs(string company);
    }
}
