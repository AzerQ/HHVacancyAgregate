using HHVacancy.Models.API.Vacancy;
using HHVacancy.Models.DB;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Storage.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace HHVacancy.Storage;

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

    public DbSet<VacancyDetailsEntity> VacancyDetails { get; set; }

    public DbSet<KeySkillEntity> KeySkills { get; set; }

    public DbSet<KeySkillVacancyLinkEntity> VacancyKeySkills { get; set; }

    private readonly IJsonDbSerializer _jsonDb;

    public HHVacancyDbContext(IJsonDbSerializer jsonDbSrializer) : base()
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

        modelBuilder.Entity<KeySkillVacancyLinkEntity>()
            .HasKey(ksvac => new
            {
                ksvac.KeySkillId,
                ksvac.VacancyId
            });

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data Source=hhvacancy.db";

        optionsBuilder.UseSqlite(connectionString)
                      //.LogTo(Console.WriteLine, (_, level) => level == LogLevel.Information)
                      .EnableSensitiveDataLogging();
    }
}

