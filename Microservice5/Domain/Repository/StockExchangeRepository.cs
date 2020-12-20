using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice3.Dtos;
using Microservice5.DataContext;
using Microservice5.Domain.Contracts;
using Microservice5.Entities;
using Microservice5.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Microservice5.Domain.Repository
{
    public class StockExchangeRepository : IStockExchangeRepository
    {
        readonly SeDBContext context;
        public StockExchangeRepository(SeDBContext context)
        {
            this.context = context;
        }

        public bool AddCompany(Company company)
        {
            
                context.Company.Add(company);
                int RowsAdded = context.SaveChanges();
                return RowsAdded > 0;

            
        }

        public bool AddStockExchange(StockExchange stockExchange)
        {
            context.StockExchange.Add(stockExchange);
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var query = from obj in context.Company
                        orderby obj.CompanyName
                        select obj;
            return query.ToList();
        }

        public IEnumerable<Company> GetAllStockExchangesToWhichACompanyBelongs(string company)
        {
            var query = from obj in context.Company
                        where obj.CompanyName == company
                        select obj;
            return query.ToList();
        }

        public IEnumerable<Company> GetCompaniesInStockExchange(string StockExchangeName)
        {
            var query = from obj in context.Company
                        orderby obj.CompanyName
                        where obj.StockExchangeName == StockExchangeName
                        select obj;
            return query.ToList();


            
        }

        public IEnumerable<StockExchange> GetStockExchanges()
        {
            var query = from obj in context.StockExchange
                        orderby obj.StockExchangeName
                        select obj;
            return query.ToList();
        }

        public bool UpdateCompanyDetailsFromMS2(Company2Dto dto)
        {
            var companies = from obj in context.Company
                            where obj.Id == dto.CompanyId
                            select obj;
            foreach (var company in companies)
            {
                company.CompanyCode = dto.CompanyCode;
                company.CompanyName = dto.CompanyName;
                
            }
            var RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }
    }
}
