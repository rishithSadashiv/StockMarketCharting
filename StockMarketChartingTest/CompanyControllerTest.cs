﻿using System;
using System.Collections.Generic;
using System.Text;
using Microservice2.Controllers;
using Microservice2.Domain.Services;
using Microservice2.Domain.Repositories;
using NUnit.Framework;
using AutoMapper;
using Microservice2.AutoMapperProfiles;
using Microservice2.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace StockMarketChartingTest
{
    [TestFixture]
    class CompanyControllerTest
    {
        CompanyController cs;

        [OneTimeSetUp]
        public void Initialize()
        {
            IConfiguration ObjConfiguration = new ConfigurationBuilder()
                                                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                            .AddJsonFile("appsettings.json")
                                                            .Build();
            string str = ObjConfiguration.GetConnectionString("constr");
            DbContextOptions<CompanyDbContext> options = new DbContextOptionsBuilder<CompanyDbContext>().UseSqlServer(str).Options;
            CompanyDbContext context = new CompanyDbContext(options);
            var repository = new CompanyRepository(context);
            Mapper ObjMapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile(new DtoMapper());
            }));
            var service = new CompanyService(repository, ObjMapper);
            cs = new CompanyController(service);
        }

        [Test]
        public void GetAllCompaniesTest_ForSuccessStatus()
        {
            var Result = cs.GetAllCompanies() as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode);
        }

    }
}
