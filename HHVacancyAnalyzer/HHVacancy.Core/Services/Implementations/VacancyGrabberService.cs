using HHVacancy.ApiClient.Services.Abstractions;
using HHVacancy.Core.Extensions;
using HHVacancy.Core.Services.Abstractions;
using HHVacancy.Models.API.Vacancy;
using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Models.DTO;
using HHVacancy.Storage.Services.Abstractions;

namespace HHVacancy.Core.Services.Implementations
{
    public class VacancyGrabberService : IVacancyGrabberService
    {
        private IVacancyApiService _apiService;
        private IVacancyMappingService _mappingService;
        private IVacancyDbService _dbService;

        public VacancyGrabberService(IVacancyApiService apiService, IVacancyMappingService vacancyMappingService, IVacancyDbService dbService)
        {
            _apiService = apiService;
            _mappingService = vacancyMappingService;
            _dbService = dbService;
        }

        public async Task<int> GrabVacancySearchResults(VacancySearchRequest request, IProgress<float> progress)
        {
            int insertedItemsCount = 0;

            await foreach (var vacancySearchPage in _apiService.SearchVacancies(request))
            {
                List<VacancySearchItem> vacancies = vacancySearchPage.Items;

                IEnumerable<VacancyEntity> dbEntities =
                   vacancies.Select(_mappingService.MapVacancyEntityFromVacancyItem);

                await _dbService.InsertVacancies(dbEntities.ToArray());

                var professionalRoleCombined = vacancies.Select(_mappingService.MapProfessionalRolesFromVacancyItem);

                var professionalRoles = professionalRoleCombined.SelectMany( el => el.profRoles).ToArray();

                await _dbService.InsertProfessionalRoles(professionalRoles);

                var professionalRolesLinks = professionalRoleCombined.SelectMany(el => el.profRoleVacancies).ToArray();

                await _dbService.InsertProfessionalRolesLinks(professionalRolesLinks);

                insertedItemsCount += dbEntities.Count();

                IEnumerable<int> vacancyIds = dbEntities.Select(vacancy => int.Parse(vacancy.Id));

                IAsyncEnumerable<List<Vacancy>> vacancyStream = _apiService.GetVacanciesByIds(vacancyIds).Buffer(20);

                await foreach (List<Vacancy> vacacncyFullDataBatch in vacancyStream)
                {
                   VacancyFullInfoDTO[] vacancyDetails = vacacncyFullDataBatch
                                                                      .Select(_mappingService.MapVacancyInfoDTOFromFullVacancy)
                                                                      .ToArray();
                      
                    await _dbService.InsertVacancyDetails(vacancyDetails);
                }

                float totalCount = Math.Min(request.MaxResults, vacancySearchPage.Found);

                float donePercent = (insertedItemsCount / totalCount) * 100;

                progress?.Report(donePercent);

            }

            return insertedItemsCount;
        }
    }
}
