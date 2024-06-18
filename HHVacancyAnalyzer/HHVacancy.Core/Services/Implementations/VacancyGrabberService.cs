using HHVacancy.ApiClient.Services.Abstractions;
using HHVacancy.Core.Services.Abstractions;
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
                List<VacancySearchItem> vacanciesSearchResults = vacancySearchPage.Items;

                IEnumerable<VacancyEntity> vacancies =
                   vacanciesSearchResults.Select(_mappingService.MapVacancyEntityFromVacancyItem);

                await _dbService.InsertVacancies(vacancies.ToArray());

                insertedItemsCount += vacancies.Count();

                IEnumerable<int> vacancyIds = vacancies.Select(vacancy => int.Parse(vacancy.Id));

                IEnumerable<VacancyDetail> vacancyDetails = await _apiService.GetVacancyDetails(vacancyIds);

                VacancyDetailDTO[] vacancyDetailDTOs = vacancyDetails
                    .Select(_mappingService.MapVacancyDetailDTOFromVacancyDetail)
                    .ToArray();

                await _dbService.InsertVacancyDetails(vacancyDetailDTOs);

                float totalCount = Math.Min(request.MaxResults, vacancySearchPage.Found);

                float donePercent = (insertedItemsCount / totalCount) * 100;

                progress?.Report(donePercent);

            }

            return insertedItemsCount;
        }
    }
}
