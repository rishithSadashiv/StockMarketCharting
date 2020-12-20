using Microservice2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice2.Domain.Contracts
{
    public interface IIpoRepository
    {
        public IEnumerable<Ipo> GetAllIpos();
        public IEnumerable<Ipo> GetIposOfCompany(string Company);
        public bool AddIpo(Ipo ipo);
        public bool UpdateIpo(Ipo ipo);
        public bool DeleteIpo(int Id);

        public Ipo GetIpo(int Id);
    }
}
