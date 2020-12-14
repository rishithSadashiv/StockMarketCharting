using Microservice01.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using Microservice01.DataContext;
using System.Data;

namespace Microservice01.Domain.Repositories
{
    public class ExcelRepository : IExcelRepository
    {
        readonly ExcelDBContext context;
        public ExcelRepository(ExcelDBContext ctx)
        {
            context = ctx;
        }
        public bool ExcelToDB(string path)
        {
            throw new Exception("Not implemented yet");
        }
    }
}
