﻿using Microservice3.DataContext;
using Microservice3.Domain.Contracts;
using Microservice3.Dtos;
using Microservice3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice3.Domain.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        readonly SectorDBContext context;
        public CompanyRepository(SectorDBContext ctx)
        {
            context = ctx;
        }

        public bool AddCompany(Company company)
        {
            context.Company.Add(company);
            int RowsAdded = context.SaveChanges();
            return RowsAdded > 0;
        }

        public IEnumerable<Company> GetCompaniesInSector(string sector)
        {
            var query = from obj in context.Company
                        orderby obj.CompanyName
                        where obj.Sector == sector
                        select obj;
            return query.ToList();
        }

        public Company GetCompany(int Id)
        {
            var company = context.Company.Find(Id);
            return company;
        }

        public int getSectorPrice(string sector)
        {
            var query = from obj in context.Company
                        orderby obj.CompanyName
                        where obj.Sector==sector
                        select obj;
            List<Company> companies = query.ToList();
            int cnt = companies.Count;
            if(cnt == 0)
            {
                return 0;
            }
            int sum = 0;
            foreach (Company c in companies)
            {
                sum += c.Turnover;
            }
            
            return sum/cnt;
        }

        public bool UpdateCompany(Company company)
        {
            var Obj = GetCompany(company.CompanyID);
            if(Obj == null)
            {
                return AddCompany(company);
            }
            Obj.CompanyCode = company.CompanyCode;
            Obj.CompanyName = company.CompanyName;
            Obj.Sector = company.Sector;
            Obj.Turnover = company.Turnover;

            //context.Company.Update(company);
            int RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }

        public bool UpdateCompanyDetailsFromMS2(Company2Dto dto)
        {
            var companies = from obj in context.Company
                            where obj.CompanyID == dto.CompanyId
                            select obj;
            foreach(var company in companies)
            {
                company.CompanyCode = dto.CompanyCode;
                company.CompanyName = dto.CompanyName;
                company.Turnover = dto.Turnover;
            }
            var RowsAffected = context.SaveChanges();
            return RowsAffected > 0;
        }
    }
}
