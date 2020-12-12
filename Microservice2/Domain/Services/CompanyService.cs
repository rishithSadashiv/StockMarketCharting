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

        public bool DeactivateCompany(int Id)
        {
            return repository.DeactivateCompany(Id);
        }

        public bool DeleteCompany(int Id)
        {
            return repository.DeleteCompany(Id);
        }

        public IEnumerable<CompanyDto> GetAllCompanies()
        {
            var companies = repository.GetAllCompanies();
            return mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public IEnumerable<CompanyDto> GetAllCompaniesLike(string Name)
        {
            var companies = repository.GetAllCompaniesLike(Name);
            return mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public CompanyDto GetCompany(int Id)
        {
            var Obj = repository.GetCompany(Id);
            var Dto = mapper.Map<CompanyDto>(Obj);
            return Dto;
        }

        public bool UpdateCompnany(CompanyDto company)
        {
            var Obj = mapper.Map<Company>(company);
            return repository.UpdateCompnany(Obj);
        }
    }
}
