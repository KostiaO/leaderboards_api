using LeaderBoards.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaderBoards.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Leader> Leaders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=LeaderBoardsDb;");
        }
    }
}