using Microservice2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Contracts
{
    public interface IStockPriceRepository
    {
        public IEnumerable<StockPrice> GetAllStockPricesOfCompany(string Company);
        public IEnumerable<StockPrice> GetAllStockPricesOfCompanyBetweenDates(string Company, DateTime FromDate, DateTime ToDate);
        public bool UpdateStockPrice(StockPrice stockPrice);
        public bool AddStockPrice(StockPrice stockPrice);
        public bool DeleteStockPrice(int Id);
        public IEnumerable<StockPrice> GetAllStockPricesOfAllCompaniesBetweenDates(DateTime FromDate, DateTime ToDate);
    }
}
