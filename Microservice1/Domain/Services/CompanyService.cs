using Microservice3.Domain.Contracts;
using Microservice3.Domain.Repositories;
using Microservice3.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microservice3.Entities;

namespace Microservice3.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        readonly ICompanyRepository repository;
        readonly IMapper mapper;
        public CompanyService(ICompanyRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public bool AddCompany(CompanyDto company)
        {
            var Obj = mapper.Map<Company>(company);
            return repository.AddCompany(Obj);
        }

        public IEnumerable<CompanyDto> GetCompaniesInSector(string sector)
        {
            var companies =  repository.GetCompaniesInSector(sector);
            return mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public CompanyDto GetCompany(int Id)
        {
            var Obj = repository.GetCompany(Id);
            var Dto = mapper.Map<CompanyDto>(Obj);
            return Dto;
        }

        public int getSectorPrice(string sector)
        {
            return repository.getSectorPrice(sector);
        }

        public bool UpdateCompany(CompanyDto company)
        {
            var Obj = mapper.Map<Company>(company);
            return repository.UpdateCompany(Obj);
        }
    }
}
