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
    public class IpoService : IIpoService
    {
        readonly IIpoRepository repository;
        readonly IMapper mapper;
        public IpoService(IIpoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public bool AddIpo(IpoDto ipo)
        {
            var Obj = mapper.Map<Ipo>(ipo);
            return repository.AddIpo(Obj);
        }

        public bool DeleteIpo(int Id)
        {
            return repository.DeleteIpo(Id);
        }

        public IEnumerable<IpoDto> GetAllIpos()
        {
            var Obj = repository.GetAllIpos();
            return mapper.Map<IEnumerable<IpoDto>>(Obj);
        }

        public IpoDto GetIpo(int Id)
        {
            var Obj = repository.GetIpo(Id);
            var Dto = mapper.Map<IpoDto>(Obj);
            return Dto;
        }

        public IEnumerable<IpoDto> GetIposOfCompany(string Company)
        {
            var Obj = repository.GetIposOfCompany(Company);
            return mapper.Map<IEnumerable<IpoDto>>(Obj);
        }

        public bool UpdateIpo(IpoDto ipo)
        {
            var Obj = mapper.Map<Ipo>(ipo);
            return repository.UpdateIpo(Obj);
        }
    }
}
