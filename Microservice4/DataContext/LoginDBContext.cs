using Microservice4.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice4.DataContext
{
    public class LoginDBContext:DbContext
    {
        public LoginDBContext(DbContextOptions<LoginDBContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}
