﻿using HHVacancy.Core.Data.Models.Entities;
using HHVacancy.Core.Data.Models.Vacancy;
using HHVacancy.Core.Data.Services.DataConverters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

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

    private readonly IJsonDbSrializer _jsonDb;

    public HHVacancyDbContext(IJsonDbSrializer jsonDbSrializer) : base()
    {
        _jsonDb = jsonDbSrializer;
        Database.EnsureCreated();
    }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        var adressJsonConverter = _jsonDb.GetJsonValueConverter<Address>();
        var contactsJsonConverter = _jsonDb.GetJsonValueConverter<Contacts>();

        modelBuilder.Entity<VacancyEntity>()
            .Property(nameof(VacancyEntity.Address))
            .HasConversion(adressJsonConverter)
            .IsRequired(false);


        modelBuilder.Entity<VacancyEntity>()
            .Property(nameof(VacancyEntity.Contacts))
            .HasConversion(contactsJsonConverter)
            .IsRequired(false);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data Source=hhvacancy.db";

        optionsBuilder.UseSqlite(connectionString)
                      .LogTo(Console.WriteLine, (_, level) => level == LogLevel.Information)
                      .EnableSensitiveDataLogging();
    }
}

