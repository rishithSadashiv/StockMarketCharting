using Microservice2.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Contracts
{
    public interface IIpoService
    {
        public IEnumerable<IpoDto> GetAllIpos();
        public IEnumerable<IpoDto> GetIposOfCompany(string Company);
        public bool AddIpo(IpoDto ipo);
        public bool UpdateIpo(IpoDto ipo);
        public bool DeleteIpo(int Id);
    }
}
