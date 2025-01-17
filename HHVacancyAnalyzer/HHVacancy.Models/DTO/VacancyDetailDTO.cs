﻿using HHVacancy.Models.DB.Entities;
using HHVacancy.Models.DB.Entities.Links;

namespace HHVacancy.Models.DTO
{
    public class VacancyDetailDTO
    {
        public VacancyDetailsEntity VacancyDetail { get; set; }

        public KeySkillEntity[] KeySkillEntities { get; set; }

        public KeySkillVacancyLinkEntity[] KeySkillVacancyLinkEntities { get; set; }

        public ProfessionalRoleEntity[] ProfessionalRoleEntities { get; set; }

        public ProfessionalRoleVacancyLinkEntity[] ProfessionalRoleVacancyLinkEntities  {get; set; }
    }
}
