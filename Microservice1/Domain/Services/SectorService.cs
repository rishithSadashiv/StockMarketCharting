using Microservice3.Domain.Contracts;
using Microservice3.Domain.Repositories;
using Microservice3.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Microservice3.Domain.Services
{
    public class SectorService : ISectorService
    {
        readonly ISectorRepository repository;
        readonly IMapper mapper;
        public SectorService(ISectorRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }
        public IEnumerable<SectorDto> getSectors()
        {
            var sectors = repository.getSectors();
            return mapper.Map<IEnumerable<SectorDto>>(sectors);
        }
    }
}
