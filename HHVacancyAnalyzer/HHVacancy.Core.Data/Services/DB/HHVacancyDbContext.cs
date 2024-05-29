using HHVacancy.Core.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HHVacancy.Core.Data.Services.DB
{
    public class HHVacancyDbContext : DbContext
    {
        public DbSet<VacancyEntity> Vacancies { get; set; }

        public DbSet<ProfessionalRoleEntity> ProfessionalRoles { get; set; }

        public DbSet<EmployerEntity> Employers { get; set; }

        public DbSet<AreaEntity> Areas { get; set; }

        public HHVacancyDbContext() : base()
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=hhvacancy.db";
            optionsBuilder.UseSqlite(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
