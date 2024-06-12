using HHVacancy.ApiClient.Services.Abstractions;
using HHVacancy.Core.Services.Abstractions;
using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;
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

        public async Task<int> GrabVacancySearchResults(VacancySearchRequest request)
        {
            int insertedItemsCount = 0;

            await foreach (var vacancySearchPage in _apiService.SearchVacancies(request))
            {

                IEnumerable<VacancyEntity> dbEntities =
                    vacancySearchPage.Items.Select(_mappingService.MapFromVacancyItem);

                await _dbService.InsertVacancies(dbEntities.ToArray());

                insertedItemsCount += dbEntities.Count();

            }

            return insertedItemsCount;
        }
    }
}
