using Microservice2.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Contracts
{
    public interface IStockPriceService
    {
        public IEnumerable<StockPriceDto> GetAllStockPricesOfCompany(string Company);
        public IEnumerable<StockPriceDto> GetAllStockPricesOfCompanyBetweenDates(string Company, DateTime FromDate, DateTime ToDate);
        public bool UpdateStockPrice(StockPriceDto stockPrice);
        public bool AddStockPrice(StockPriceDto stockPrice);
        public bool DeleteStockPrice(int Id);
        public IEnumerable<StockPriceDto> GetAllStockPricesOfAllCompaniesBetweenDates(DateTime FromDate, DateTime ToDate);
    }
}
