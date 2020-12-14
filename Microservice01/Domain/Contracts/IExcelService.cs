using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice01.Domain.Contracts
{
    public interface IExcelService
    {
        public bool ExcelToDB(string Path);
    }
}
