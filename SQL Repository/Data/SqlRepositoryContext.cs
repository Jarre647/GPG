using Microsoft.EntityFrameworkCore;
using SQL_Repository.Models;

namespace SQL_Repository.Data
{
    public class SqlRepositoryContext : DbContext
    {
        public SqlRepositoryContext (DbContextOptions<SqlRepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<Grudge> Grudge { get; set; }
    }
}
