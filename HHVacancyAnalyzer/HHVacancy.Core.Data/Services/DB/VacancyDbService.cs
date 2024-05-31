using System.Threading.Tasks;
using HHVacancy.Core.Data.Models.Entities;
using HHVacancy.Core.Data.Services.DB;
using Microsoft.EntityFrameworkCore;

namespace HHVacancy.Core.Data;

public class VacancyDbService : IVacancyDbService
{
    private readonly HHVacancyDbContext _vacancyDbContext;
    public VacancyDbService(HHVacancyDbContext vacancyDbContext)
    {
        _vacancyDbContext = vacancyDbContext;
    }

    public async Task AddOrUpdateAreas(params AreaEntity[] areas)
    {
        throw new System.NotImplementedException();
    }

    public async Task AddOrUpdateEmployers(params EmployerEntity[] employers)
    {
        throw new System.NotImplementedException();
    }

    public async Task AddOrUpdateEmployments(params EmploymentEntity[] employments)
    {
       throw new System.NotImplementedException();
    }

    public async Task AddOrUpdateExperienceItems(params ExperienceEntity[] experienceItems)
    {
        throw new System.NotImplementedException();
    }

    public async Task AddOrUpdateProfessionalRoles(params ProfessionalRoleEntity[] professionalRoles)
    {
        throw new System.NotImplementedException();
    }

    public async Task AddOrUpdateSchedules(params ScheduleEntity[] schedules)
    {
        throw new System.NotImplementedException();
    }

    public async Task AddOrUpdateVacancies(params VacancyEntity[] vacancies)
    {
        throw new System.NotImplementedException();
    }

    public async Task AddOrUpdateVacancyTypes(params VacancyTypeEntity[] vacacncyTypeEntity)
    {
        throw new System.NotImplementedException();
    }
}
