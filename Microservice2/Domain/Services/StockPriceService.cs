using AutoMapper;
using Microservice2.Domain.Contracts;
using Microservice2.Dtos;
using Microservice2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Services
{
    public class StockPriceService : IStockPriceService
    {
        readonly IStockPriceRepository repository;
        readonly IMapper mapper;
        public StockPriceService(IStockPriceRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public bool AddStockPrice(StockPriceDto stockPrice)
        {
            var Obj = mapper.Map<StockPrice>(stockPrice);
            return repository.AddStockPrice(Obj);
        }

        public bool DeleteStockPrice(int Id)
        {
            return repository.DeleteStockPrice(Id);
        }

        public IEnumerable<StockPriceDto> GetAllStockPricesOfAllCompaniesBetweenDates(DateTime FromDate, DateTime ToDate)
        {
            var Obj = repository.GetAllStockPricesOfAllCompaniesBetweenDates(FromDate, ToDate);
            return mapper.Map<IEnumerable<StockPriceDto>>(Obj);
        }

        public IEnumerable<StockPriceDto> GetAllStockPricesOfCompany(string Company)
        {
            var Obj = repository.GetAllStockPricesOfCompany(Company);
            return mapper.Map<IEnumerable<StockPriceDto>>(Obj);
        }

        public IEnumerable<StockPriceDto> GetAllStockPricesOfCompanyBetweenDates(string Company, DateTime FromDate, DateTime ToDate)
        {
            var Obj = repository.GetAllStockPricesOfCompanyBetweenDates(Company, FromDate, ToDate);
            return mapper.Map<IEnumerable<StockPriceDto>>(Obj);
        }

        public bool UpdateStockPrice(StockPriceDto stockPrice)
        {
            var Obj = mapper.Map<StockPrice>(stockPrice);
            return repository.UpdateStockPrice(Obj);
        }
    }
}
