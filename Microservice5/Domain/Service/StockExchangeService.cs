﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice5.Domain.Contracts;
using Microservice5.Dtos;
using AutoMapper;
using Microservice5.Entities;

namespace Microservice5.Domain.Service
{
    public class StockExchangeService : IStockExchangeService
    {
        readonly IStockExchangeRepository repository;
        readonly IMapper mapper;
        public StockExchangeService(IStockExchangeRepository repo, IMapper mapper)
        {
            repository = repo;
            this.mapper = mapper;
        }
        public bool AddCompany(CompanyDto company)
        {
            var Obj = mapper.Map<Company>(company);
            return repository.AddCompany(Obj);
        }

        public bool AddStockExchange(StockExchangeDto stockExchange)
        {
            var Obj = mapper.Map<StockExchange>(stockExchange);
            return repository.AddStockExchange(Obj);
        }

        public IEnumerable<CompanyDto> GetCompaniesInStockExchange(string StockExchangeName)
        {
            var Obj = repository.GetCompaniesInStockExchange(StockExchangeName);
            return mapper.Map<IEnumerable<CompanyDto>>(Obj);
        }

        public IEnumerable<StockExchangeDto> GetStockExchanges()
        {
            var Obj = repository.GetStockExchanges();
            return mapper.Map<IEnumerable<StockExchangeDto>>(Obj);
        }
    }
}
