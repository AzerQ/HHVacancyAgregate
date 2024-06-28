using HHVacancy.Models.API;
using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Models.DB.Entities.Links;
using HHVacancy.Models.DTO;
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

    public VacancyDetailDTO MapVacancyDetailDTOFromVacancyDetail(IVacancyDetail vacancyDetailItem)
    {
        var vacancyDetail = new VacancyDetailsEntity
        {
            Description = vacancyDetailItem.Description,
            VacancyId = vacancyDetailItem.Id
        };

        var keySkillEntities = vacancyDetailItem.KeySkills
                                    .Select(keySkill => new KeySkillEntity
                                    {
                                        Id = GenerateKeySkillId(keySkill.Name),
                                        Name = keySkill.Name
                                    }).ToArray();

        var keySkillLinks = keySkillEntities
                                    .Select(keySkill => new KeySkillVacancyLinkEntity
                                    {
                                        KeySkillId = keySkill.Id,
                                        VacancyId = vacancyDetailItem.Id
                                    }).ToArray();

        var professionalRolesEntities = vacancyDetailItem.ProfessionalRoles
            .Select(role => role.Adapt<ProfessionalRoleEntity>())
            .ToArray();

        var proffesionalRoleLinks = professionalRolesEntities
            .Select(role =>
            new ProfessionalRoleVacancyLinkEntity
            {
                ProfessionalRoleId = role.Id,
                VacancyId = vacancyDetail.VacancyId
            }).ToArray();


        return new VacancyDetailDTO
        {
            KeySkillEntities = keySkillEntities,
            KeySkillVacancyLinkEntities = keySkillLinks,
            VacancyDetail = vacancyDetail,
            ProfessionalRoleEntities = professionalRolesEntities,
            ProfessionalRoleVacancyLinkEntities = proffesionalRoleLinks
        };
    }

    public VacancyEntity MapVacancyEntityFromVacancyItem(VacancySearchItem vacancyItem)
    {
        return vacancyItem.Adapt<VacancyEntity>();
    }

}

