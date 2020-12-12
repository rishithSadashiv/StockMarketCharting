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
            context.StockPrice.Add(stockPrice);
            int RowsAdded = context.SaveChanges();
            return RowsAdded > 0;
        }

        public bool DeleteStockPrice(int Id)
        {
            var Obj = context.StockPrice.Find(Id);
            context.StockPrice.Remove(Obj);
            int RowsDeleted = context.SaveChanges();
            return RowsDeleted > 0;
        }

        public IEnumerable<StockPrice> GetAllStockPricesOfCompany(string Company)
        {
            var StockPrices = context.StockPrice.Where(x => x.CompanyName.Equals(Company)).ToList();
            return StockPrices;
        }

        public IEnumerable<StockPrice> GetAllStockPricesOfCompanyBetweenDates(string Company, DateTime FromDate, DateTime ToDate)
        {
            var StockPrices = context.StockPrice.Where(x => x.CompanyName.Equals(Company) && x.DateOfPrice >= FromDate && x.DateOfPrice <= ToDate);
            return StockPrices;
        }


        public IEnumerable<StockPrice> GetAllStockPricesOfAllCompaniesBetweenDates(DateTime FromDate, DateTime ToDate)
        {
            var StockPrices = context.StockPrice.Where(x => x.DateOfPrice >= FromDate && x.DateOfPrice <= ToDate);
            return StockPrices;
        }


        public bool UpdateStockPrice(StockPrice stockPrice)
        {
            context.StockPrice.Update(stockPrice);
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }
    }
}
