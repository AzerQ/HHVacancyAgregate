using HHVacancy.Models.API.Vacancy;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Models.DB.Entities.Links;
using HHVacancy.Models.DTO;
using HHVacancy.Storage.Extensions;
using HHVacancy.Storage.Services.Abstractions;
using Microsoft.EntityFrameworkCore;


namespace HHVacancy.Storage.Services.Implementations;

public class VacancyDbService : IVacancyDbService
{
    private readonly HHVacancyDbContext _dbContext;


    public VacancyDbService(HHVacancyDbContext context)
    {
        _dbContext = context;
    }

    private async Task InsertEntites<TEntity, TKey>(Func<HHVacancyDbContext, DbSet<TEntity>> dbSetGetter,
    IEnumerable<TEntity> entities, Func<TEntity, TKey> keySelector) where TEntity : class

    {
        var distinctById = entities.DistinctBy(keySelector);
        var dbSet = dbSetGetter(_dbContext);
        await dbSet.AddRangeIfNotExists(distinctById, keySelector);
        await _dbContext.SaveChangesAsync();

    }

    public async Task InsertAreas(params AreaEntity[] areas)
    {
        await InsertEntites(db => db.Areas, areas, area => area.Id);
    }

    public async Task InsertEmployers(params EmployerEntity[] employers)
    {
        await InsertEntites(db => db.Employers, employers, employer => employer.Id);
    }

    public async Task InsertEmployments(params EmploymentEntity[] employments)
    {
        await InsertEntites(db => db.Employments, employments, employement => employement.Id);
    }

    public async Task InsertExperienceItems(params ExperienceEntity[] experienceItems)
    {
        await InsertEntites(db => db.Experiences, experienceItems, experience => experience.Id);
    }

    public async Task InsertProfessionalRoles(params ProfessionalRoleEntity[] professionalRoles)
    {
        await InsertEntites(db => db.ProfessionalRoles, professionalRoles, professionalRole => professionalRole.Id);
    }

    public async Task InsertProfessionalRolesLinks(params ProfessionalRoleVacancyLinkEntity[] professionalRoleVacancyLinks)
    {
        await InsertEntites(db => db.ProfessionalRoleVacancies, professionalRoleVacancyLinks, profRoleVacancy =>
        new
        {
            profRoleVacancy.ProfessionalRoleId,
            profRoleVacancy.VacancyId
        });
    }

    public async Task InsertSchedules(params ScheduleEntity[] schedules)
    {
        await InsertEntites(db => db.Schedules, schedules, schedule => schedule.Id);
    }

    public async Task InsertVacancyTypes(params VacancyTypeEntity[] vacacncyTypeEntitities)
    {
        await InsertEntites(db => db.VacacncyTypes, vacacncyTypeEntitities, vacacnyType => vacacnyType.Id);
    }

    private void ClearVacancyLinkedObjects(VacancyEntity vacancy)
    {
        // Чистим ссылки для нормльного сохранения в контексте объектов (Для избежания дубликтов)

        vacancy.Area = null;
        vacancy.Employer = null;
        vacancy.Employment = null;
        vacancy.Experience = null;
        vacancy.Schedule = null;
        vacancy.Type = null;
    }

    public async Task InsertVacancies(params VacancyEntity[] vacancies)
    {
        IEnumerable<AreaEntity> areas = vacancies.Select(vacancy => vacancy.Area);
        await InsertAreas(areas.ToArray());

        IEnumerable<EmployerEntity> employers = vacancies.Select(vacancy => vacancy.Employer);
        await InsertEmployers(employers.ToArray());

        IEnumerable<EmploymentEntity> employments = vacancies.Select(vacancy => vacancy.Employment);
        await InsertEmployments(employments.ToArray());

        IEnumerable<ExperienceEntity> experienceItems = vacancies.Select(vacancy => vacancy.Experience);
        await InsertExperienceItems(experienceItems.ToArray());

        IEnumerable<ScheduleEntity> schedules = vacancies.Select(vacancy => vacancy.Schedule);
        await InsertSchedules(schedules.ToArray());

        IEnumerable<VacancyTypeEntity> vacancyTypes = vacancies.Select(vacancy => vacancy.Type);
        await InsertVacancyTypes(vacancyTypes.ToArray());

        foreach (var vacancy in vacancies)
        {
            ClearVacancyLinkedObjects(vacancy);
        }

        await InsertEntites(db => db.Vacancies, vacancies, vacancy => vacancy.Id);

    }

    public async Task InsertVacancyDetails(params VacancyDetailDTO[] vacancyFullInfo)
    {
        await InsertEntites(db => db.VacancyDetails,
            vacancyFullInfo.Select(info => info.VacancyDetail),
            vacancyDetail => vacancyDetail.VacancyId);

        await InsertEntites(db => db.KeySkills,
            vacancyFullInfo.SelectMany(info => info.KeySkillEntities),
            keySkill => keySkill.Id);

        await InsertEntites(db => db.VacancyKeySkills,
              vacancyFullInfo.SelectMany(info => info.KeySkillVacancyLinkEntities),
              ksvac => new { ksvac.VacancyId, ksvac.KeySkillId });

        await InsertProfessionalRoles(vacancyFullInfo
            .SelectMany(info => info.ProfessionalRoleEntities)
            .ToArray());

        await InsertProfessionalRolesLinks(vacancyFullInfo
            .SelectMany(info => info.ProfessionalRoleVacancyLinkEntities)
            .ToArray());
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext?.Dispose();
        }
    }


    public void Dispose()
    {
        // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

}
