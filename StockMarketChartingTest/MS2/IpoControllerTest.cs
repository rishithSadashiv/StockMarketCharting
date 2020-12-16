using Microservice2.Controllers;
using Microservice2.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Microservice2.Dtos;
using System.Web.Http;
using System.Linq;
using Microservice2.Domain.Services;
using Microservice2.Entities;

namespace StockMarketChartingTest.MS2
{
    [TestFixture]
    class IpoControllerTest
    {

        [Test]
        public void GetAllIpos_TestForOk()
        {
            var mockRepository = new Mock<IIpoService>();
            var ic = new IpoController(mockRepository.Object);
            var Result = ic.GetAllIpos() as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode);
        }
        [Test]
        public void GetIposOfCompany_TestForOk()
        {
            var mockRepository = new Mock<IIpoService>();
            mockRepository.Setup(x => x.GetIposOfCompany(string.Empty)).Returns(Enumerable.Empty<IpoDto>().AsQueryable());

            var controller = new IpoController(mockRepository.Object);
            var Result = controller.GetIposOfCompany(string.Empty) as ObjectResult;
            Assert.AreEqual(200, Result.StatusCode);
        }
        [Test]
        public void AddIpo_TestFor200()
        {
            var ipo = new IpoDto
            {
                CompanyName = "company1325",
                StockExchange = "bse",
                PricePerShare = 52,
                TotalNumberOfShares = 10000,
                OpenDateTime = new DateTime().Date,
                Remarks = "some comment"
            };

            var mockRepository = new Mock<IIpoService>();
            mockRepository.Setup(x => x.AddIpo(It.IsAny<IpoDto>())).Returns(true);

            var controller = new IpoController(mockRepository.Object);
            var result = controller.AddIpo(ipo) as OkObjectResult;
            Assert.AreEqual(201, result);
        }
        [Test]
        public void AddIpo_TestFor400()
        {
            var mockRepository = new Mock<IIpoService>();
            mockRepository.Setup(instance => instance.AddIpo(It.IsAny<IpoDto>())).Returns(true);

            var ic = new IpoController(mockRepository.Object);
            var Result = ic.AddIpo(new IpoDto(){}) as ObjectResult;
            Assert.AreEqual(400, Result.StatusCode);
            
        }


        [Test]
        public void AddIpo_service_Test_ok()
        {
            var mockRepo = new Mock<IIpoService>();
            mockRepo.Setup(i => i.AddIpo(It.IsAny<IpoDto>())).Returns(true);

            var controller = new IpoController(mockRepo.Object);
            var Result = controller.AddIpo(new IpoDto { });
            Assert.AreEqual(400, Result.GetType());
            
        }



    }
}
