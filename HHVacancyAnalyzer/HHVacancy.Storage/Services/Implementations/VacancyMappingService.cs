using HHVacancy.Models.API.Vacancy;
using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Storage.Services.Abstractions;
using Mapster;

namespace HHVacancy.Storage.Services.Implementations;

public class VacancyMappingService : IVacancyMappingService
{
    private ITransliterationService _transliterationService;

    public VacancyMappingService(ITransliterationService transliterationService)
    {
        _transliterationService = transliterationService;
    }

    private string GenerateKeySkillId(string keySkillName)
    {
        string clearKeySkill = keySkillName
                                 .Trim()
                                 .ToLower()
                                 .Replace(" ", "_");
                                 
        return _transliterationService.IsRuString(clearKeySkill) ? 
             _transliterationService.ConvertToLatin(clearKeySkill)
             : clearKeySkill;
    }

    public VacancyFullInfoDTO MapFromFullVacancy(Vacancy fullVacancy)
    {
        var vacancyDetail = new VacancyDetailsEntity
        {
            Description = fullVacancy.Description,
            VacancyId = fullVacancy.Id
        };

        KeySkillEntity[] keySkillEntities = fullVacancy.KeySkills.Select(keySkill => new KeySkillEntity
        {
            Id = GenerateKeySkillId(keySkill.Name),
            Name = keySkill.Name
        }).ToArray();

        KeySkillVacancyLinkEntity[] keySkillLinks = keySkillEntities.Select(keySkill => new KeySkillVacancyLinkEntity
        {
            KeySkillId = keySkill.Id,
            VacancyId = fullVacancy.Id
        }).ToArray();


        return new VacancyFullInfoDTO
        {
            KeySkillEntities = keySkillEntities,
            KeySkillVacancyLinkEntities = keySkillLinks,
            VacancyDetail = vacancyDetail
        };
    }

    public VacancyEntity MapFromVacancyItem(VacancySearchItem vacancyItem)
    {
        return vacancyItem.Adapt<VacancyEntity>();
    }
}

