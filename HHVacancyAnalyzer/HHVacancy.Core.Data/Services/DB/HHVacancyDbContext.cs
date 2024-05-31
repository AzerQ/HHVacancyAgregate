using HHVacancy.Core.Data.Models.Entities;
using HHVacancy.Core.Data.Models.Vacancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;

namespace HHVacancy.Core.Data.Services.DB;

    public class HHVacancyDbContext : DbContext
    {
        public DbSet<AreaEntity> Areas { get; set; }

        public DbSet<EmployerEntity> Employers { get; set; }

        public DbSet<EmploymentEntity> Employments { get; set; }

        public DbSet<ExperienceEntity> Experiences { get; set; }

        public DbSet<ProfessionalRoleEntity> ProfessionalRoles { get; set; }

        public DbSet<ScheduleEntity> Schedules { get; set; }

        public DbSet<VacancyTypeEntity> VacacncyTypes { get; set; }

        public DbSet<VacancyEntity> Vacancies { get; set; }


        public HHVacancyDbContext() : base()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        private string JsonSerialize(object obj) => JsonSerializer.Serialize(obj);

        private T? JsonDeserialize<T>(string str) => JsonSerializer.Deserialize<T>(str);

        private ValueConverter<T, string> GetJsonValueConverter<T>() =>
            new ValueConverter<T, string>(
                    v => JsonSerialize(v),
                    v => JsonDeserialize<T>(v)
            );

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var adressJsonConverter = GetJsonValueConverter<Address>();
            var contactsJsonConverter = GetJsonValueConverter<Contacts>();

            modelBuilder.Entity<VacancyEntity>()
                .Property(nameof(VacancyEntity.Address))
                .HasConversion(adressJsonConverter);

            modelBuilder.Entity<VacancyEntity>()
                .Property(nameof(VacancyEntity.Contacts))
                .HasConversion(contactsJsonConverter);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=hhvacancy.db";

            optionsBuilder.UseSqlite(connectionString)
                          .LogTo(Console.WriteLine, (_, level) => level == LogLevel.Information)
                          .EnableSensitiveDataLogging();

        }
    }

