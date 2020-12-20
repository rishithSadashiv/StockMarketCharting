using AutoMapper;
using AutoMapper.Configuration;
using Microservice2.AutoMapperProfiles;
using Microservice2.Controllers;
using Microservice2.Domain.Contracts;
using Microservice2.Domain.Services;
using Microservice2.Dtos;
using Microservice2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace StockMarketChartingTest.MS2
{
    [TestFixture]
    class StockPriceTest
    {

        

        [OneTimeSetUp]
        public void Initialize()
        {
           

        }

        [Test]
        public void GetStockPricesOfCompany_testok()
        {
            var mockRepository = new Mock<IStockPriceService>();
            mockRepository.Setup(x => x.GetAllStockPricesOfCompany(string.Empty)).Returns(Enumerable.Empty<StockPriceDto>().AsQueryable());

            var controller = new StockPriceController(mockRepository.Object);
            var Result = controller.GetStockPricesOfCompany(string.Empty) as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode);
        }
        [Test]
        public void GetAllStockPricesOfCompanyBetweenDates_TestOk()
        {
            var mockRepository = new Mock<IStockPriceService>();
            mockRepository.Setup(x => x.GetAllStockPricesOfCompanyBetweenDates(string.Empty, new DateTime(), new DateTime()))
                .Returns(Enumerable.Empty<StockPriceDto>().AsQueryable());

            var controller = new StockPriceController(mockRepository.Object);
            var Result = controller.GetAllStockPricesOfCompanyBetweenDates(string.Empty,new DateTime(),new DateTime()) as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode);
        }

        [Test]
        public void GetAllStockPricesOfAllCompaniesBetweenDates_TestOk()
        {
            var mockRepository = new Mock<IStockPriceService>();
            mockRepository.Setup(x => x.GetAllStockPricesOfAllCompaniesBetweenDates(new DateTime(), new DateTime()))
                .Returns(Enumerable.Empty<StockPriceDto>().AsQueryable());

            var controller = new StockPriceController(mockRepository.Object);
            var Result = controller.GetAllStockPricesOfAllCompaniesBetweenDates(new DateTime(), new DateTime()) as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode);
        }

        [Test]
        public void ServiceTest_AddStockPrice()
        {
            var mockMapper = new Mock<DtoMapper>();
            var mockRepository = new Mock<IStockPriceRepository>();
            mockRepository.Setup(x => x.AddStockPrice(It.IsAny<StockPrice>())).Returns(true);

            var service = new StockPriceService(mockRepository.Object, (IMapper)mockMapper.Object);


        }
    }

}
