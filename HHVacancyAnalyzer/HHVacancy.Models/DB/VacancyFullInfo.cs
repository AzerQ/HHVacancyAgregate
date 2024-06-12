using HHVacancy.Models.DB.Entities;

namespace HHVacancy.Models.DB
{
    public class VacancyFullInfoDTO
    {
        public VacancyDetailsEntity VacancyDetail { get; set; }

        public KeySkillEntity[] KeySkillEntities { get; set; }

        public KeySkillVacancyLinkEntity[] KeySkillVacancyLinkEntities { get; set; }
    }
}
