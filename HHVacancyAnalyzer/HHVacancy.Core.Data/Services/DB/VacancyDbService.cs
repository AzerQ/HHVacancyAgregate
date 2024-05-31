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

    public async Task AddOrUpdateVacancies(params VacancyEntity[] vacancies)
    {
        await _vacancyDbContext.Vacancies.AddOrUpdateRangeAsync(vacancies);
    }

    public async Task AddOrUpdateVacancyTypes(params VacancyTypeEntity[] vacacncyTypeEntitities)
    {
        await _vacancyDbContext.VacacncyTypes.AddOrUpdateRangeAsync(vacacncyTypeEntitities);
    }
}
