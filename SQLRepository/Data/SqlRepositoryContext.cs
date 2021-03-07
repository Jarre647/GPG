using Microsoft.EntityFrameworkCore;
using SQLRepository.Client.Models;

namespace SQLRepository.Data
{
    public class SqlRepositoryContext : DbContext
    {
        public SqlRepositoryContext(DbContextOptions<SqlRepositoryContext> options)
            : base(options)
        {
        }

        public DbSet<GrudgeModel> Grudge { get; set; }
    }
}
