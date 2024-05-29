using HHVacancy.Core.Data.Models.Entities;
using HHVacancy.Core.Data.Models.VacancySearch;
using Mapster;

namespace HHVacancy.Core.Data.Services
{
    public class VacancyMappingService : IVacancyMappingService
    {
        public VacancyEntity MapFromVacancyItem(VacancyItem vacancyItem)
        {
            return vacancyItem.Adapt<VacancyEntity>();
        }
    }
}
