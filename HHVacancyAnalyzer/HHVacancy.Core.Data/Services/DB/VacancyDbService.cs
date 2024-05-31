using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HHVacancy.Core.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace HHVacancy.Core.Data.Services.DB;

public class VacancyDbService : IVacancyDbService
{

    public VacancyDbService()
    {

    }

    private async Task InsertEntites<TEntity, TKey>(Func<HHVacancyDbContext, DbSet<TEntity>> dbSetGetter,
    IEnumerable<TEntity> entities, Func<TEntity, TKey> keySelector) where TEntity : class
    {
        using (var db = new HHVacancyDbContext())
        {
            var dbSet = dbSetGetter(db);
            await dbSet.AddRangeIfNotExists(entities, keySelector);
            await db.SaveChangesAsync();
        }
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

    public async Task InsertSchedules(params ScheduleEntity[] schedules)
    {
        await InsertEntites(db => db.Schedules, schedules, schedule => schedule.Id);
    }
    private void ClearVacancyLinkedObjects(VacancyEntity vacancy)
    {
        // Чистим ссылки для нормльного сохранения в контексте объектов (Для избежания дубликтов)

        vacancy.Area = null;
        vacancy.Employer = null;
        vacancy.Employment = null;
        vacancy.Experience = null;
        vacancy.ProfessionalRoles = null;
        vacancy.Schedule = null;
        vacancy.Type = null;

    }

    public async Task InsertVacancies(params VacancyEntity[] vacancies)
    {
        var areas = vacancies.Select(vacancy => vacancy.Area).DistinctBy(area => area.Id);
        await InsertAreas(areas.ToArray());

        var employers = vacancies.Select(vacancy => vacancy.Employer).DistinctBy(employer => employer.Id);
        await InsertEmployers(employers.ToArray());

        var employments = vacancies.Select(vacancy => vacancy.Employment).DistinctBy(employement => employement.Id);
        await InsertEmployments(employments.ToArray());

        var experienceItems = vacancies.Select(vacancy => vacancy.Experience).DistinctBy(experience => experience.Id);
        await InsertExperienceItems(experienceItems.ToArray());

        var professionalRoles = vacancies.SelectMany(vacancy => vacancy.ProfessionalRoles).DistinctBy(professionalRole => professionalRole.Id);
        await InsertProfessionalRoles(professionalRoles.ToArray());

        var schedules = vacancies.Select(vacancy => vacancy.Schedule).DistinctBy(schedule => schedule.Id);
        await InsertSchedules(schedules.ToArray());

        var vacancyTypes = vacancies.Select(vacancy => vacancy.Type).DistinctBy(vacancyType => vacancyType.Id);
        await InsertSchedules(schedules.ToArray());

        foreach (var vacancy in vacancies)
        {
            ClearVacancyLinkedObjects(vacancy);
        }

        await InsertEntites(db => db.Vacancies, vacancies, vacancy => vacancy.Id);

    }

    public async Task InsertVacancyTypes(params VacancyTypeEntity[] vacacncyTypeEntitities)
    {
        await InsertEntites(db => db.VacacncyTypes, vacacncyTypeEntitities, vacacnyType => vacacnyType.Id);
    }

}
