using System.Linq;
using System.Threading.Tasks;
using HHVacancy.Core.Data.Models.Entities;


namespace HHVacancy.Core.Data.Services.DB;

public class VacancyDbService : IVacancyDbService
{
    private readonly HHVacancyDbContext _vacancyDbContext;
    public VacancyDbService(HHVacancyDbContext vacancyDbContext)
    {
        _vacancyDbContext = vacancyDbContext;
    }


    public async Task AddOrUpdateAreas(params AreaEntity[] areas)
    {
        await _vacancyDbContext.Areas.AddOrUpdateRangeAsync(areas);
    }

    public async Task AddOrUpdateEmployers(params EmployerEntity[] employers)
    {
        await _vacancyDbContext.Employers.AddOrUpdateRangeAsync(employers);
    }

    public async Task AddOrUpdateEmployments(params EmploymentEntity[] employments)
    {
        await _vacancyDbContext.Employments.AddOrUpdateRangeAsync(employments);
    }

    public async Task AddOrUpdateExperienceItems(params ExperienceEntity[] experienceItems)
    {
        await _vacancyDbContext.Experiences.AddOrUpdateRangeAsync(experienceItems);
    }

    public async Task AddOrUpdateProfessionalRoles(params ProfessionalRoleEntity[] professionalRoles)
    {
        await _vacancyDbContext.ProfessionalRoles.AddOrUpdateRangeAsync(professionalRoles);
    }

    public async Task AddOrUpdateSchedules(params ScheduleEntity[] schedules)
    {
        await _vacancyDbContext.Schedules.AddOrUpdateRangeAsync(schedules);
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

    public async Task AddOrUpdateVacancies(params VacancyEntity[] vacancies)
    {
        var areas = vacancies.Select(vacancy => vacancy.Area).DistinctBy(area => area.Id);
        await AddOrUpdateAreas(areas.ToArray());

        var employers = vacancies.Select(vacancy => vacancy.Employer).DistinctBy(employer => employer.Id);
        await AddOrUpdateEmployers(employers.ToArray());

        var employments = vacancies.Select(vacancy => vacancy.Employment).DistinctBy(employement => employement.Id);
        await AddOrUpdateEmployments(employments.ToArray());

        var experienceItems = vacancies.Select(vacancy => vacancy.Experience).DistinctBy(experience => experience.Id);
        await AddOrUpdateExperienceItems(experienceItems.ToArray());

        var professionalRoles = vacancies.SelectMany(vacancy => vacancy.ProfessionalRoles).DistinctBy(professionalRole => professionalRole.Id);
        await AddOrUpdateProfessionalRoles(professionalRoles.ToArray());

        var schedules = vacancies.Select(vacancy => vacancy.Schedule).DistinctBy(schedule => schedule.Id);
        await AddOrUpdateSchedules(schedules.ToArray());

        var vacancyTypes = vacancies.Select(vacancy => vacancy.Type).DistinctBy(vacancyType => vacancyType.Id);
        await AddOrUpdateSchedules(schedules.ToArray());

        foreach (var vacancy in vacancies)
        {
            ClearVacancyLinkedObjects(vacancy);
        }
        await _vacancyDbContext.Vacancies.AddOrUpdateRangeAsync(vacancies);

    }

    public async Task AddOrUpdateVacancyTypes(params VacancyTypeEntity[] vacacncyTypeEntitities)
    {
        await _vacancyDbContext.VacacncyTypes.AddOrUpdateRangeAsync(vacacncyTypeEntitities);
    }

    public async Task SaveChanges() => await _vacancyDbContext.SaveChangesAsync();
}
