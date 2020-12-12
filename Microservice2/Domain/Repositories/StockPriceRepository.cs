using Microservice2.DataContext;
using Microservice2.Domain.Contracts;
using Microservice2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Repositories
{
    public class StockPriceRepository : IStockPriceRepository
    {

        readonly CompanyDbContext context;
        public StockPriceRepository(CompanyDbContext ctx)
        {
            context = ctx;
        }
        public bool AddStockPrice(StockPrice stockPrice)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStockPrice(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockPrice> GetAllStockPricesOfCompany(string Company)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockPrice> GetAllStockPricesOfCompanyBetweenDates(string Company, DateTime FromDate, DateTime ToDate)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStockPrice(StockPrice stockPrice)
        {
            throw new NotImplementedException();
        }
    }
}
