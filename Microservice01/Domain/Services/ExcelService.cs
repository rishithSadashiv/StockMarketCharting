using Microservice01.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice01.Domain.Services
{
    public class ExcelService : IExcelService
    {
        readonly IExcelRepository repository;
        public ExcelService(IExcelRepository repo)
        {
            repository = repo;
        }
        public bool ExcelToDB(string Path)
        {
            return repository.ExcelToDB(Path);
        }
    }
}
