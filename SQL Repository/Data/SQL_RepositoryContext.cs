using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQL_Repository.Models;

namespace SQL_Repository.Data
{
    public class SQL_RepositoryContext : DbContext
    {
        public SQL_RepositoryContext (DbContextOptions<SQL_RepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<SQL_Repository.Models.Abuser> Abuser { get; set; }
    }
}
