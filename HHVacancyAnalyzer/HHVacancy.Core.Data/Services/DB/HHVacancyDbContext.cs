using Microsoft.EntityFrameworkCore;

namespace HHVacancy.Core.Data.Services.DB
{
    public class HHVacancyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=hhvacancy.db";
            optionsBuilder.UseSqlite(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
