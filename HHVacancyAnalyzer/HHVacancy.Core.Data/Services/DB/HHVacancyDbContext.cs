using HHVacancy.Core.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace HHVacancy.Core.Data.Services.DB
{
    public class HHVacancyDbContext : DbContext
    {
        public DbSet<AreaEntity> Areas { get; set; }

        public DbSet<EmployerEntity> Employers { get; set; }

        public DbSet<ExperienceEntity> Experiences { get; set; }

        public DbSet<ProfessionalRoleEntity> ProfessionalRoles { get; set; }

        public DbSet<ScheduleEntity> Schedules { get; set; }

        public DbSet<VacacncyTypeEntity> VacacncyTypes { get; set; }

        public DbSet<VacancyEntity> Vacancies { get; set; }


        public HHVacancyDbContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VacancyEntity>()
                .OwnsOne(vacancy => vacancy.Address,
                builder => builder.ToJson())
                .OwnsOne(vacancy => vacancy.Contacts,
                builder => builder.ToJson())
                .OwnsMany(vacancy=>vacancy.Relations,
                builder => builder.ToJson());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=hhvacancy.db";

            optionsBuilder.UseSqlite(connectionString)
                          .LogTo(Console.WriteLine, (_, level) => level == LogLevel.Information)
                          .EnableSensitiveDataLogging();

        }
    }
}
