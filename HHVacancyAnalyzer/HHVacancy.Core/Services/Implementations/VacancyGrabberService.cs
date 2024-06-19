using HHVacancy.ApiClient.Services.Abstractions;
using HHVacancy.Core.Services.Abstractions;
using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Models.DTO;
using HHVacancy.Storage.Services.Abstractions;

namespace HHVacancy.Core.Services.Implementations
{
    class VacanciesWorkProgress
    {
        public double InsertedCount { get; set; }

        public double TotalCount { get; set; }

        public double TotalProgress => InsertedCount / TotalCount;

        public bool IsDone => InsertedCount >= TotalCount;
    }

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

        public int MaxSearchResultsByQuery => 10_000;

        private TimeSpan[] _avaibleIntervals = [TimeSpan.FromDays(60),TimeSpan.FromDays(45), TimeSpan.FromDays(30),
                                               TimeSpan.FromDays(14),TimeSpan.FromDays(7), TimeSpan.FromDays(3)];

        /// <summary>
        /// Подбор интервала для ограничения поиска вакансий по датам
        /// </summary>
        /// <param name="vacancySearchRequest">Поисковый запрос вакансий</param>
        /// <returns>Наиболее подходящий интервал между датами в  днях</returns>
        private async Task<TimeSpan> ProbeInterval(VacancySearchRequest vacancySearchRequest)
        {
            var sortedIntervals = _avaibleIntervals.OrderByDescending(item => item);

            DateTime now = DateTime.Now;

            foreach (TimeSpan interval in sortedIntervals)
            {
                DateTime startDate = now.Subtract(interval);

                vacancySearchRequest.DateFrom = startDate;
                vacancySearchRequest.DateTo = now;

                int resultsCount = await _apiService.GetSearchQueryResultsCount(vacancySearchRequest);

                if (resultsCount <= _apiService.MaxSearchResults)
                {
                    return interval;
                }
            }

            return sortedIntervals.Last();
        }

        private async Task<int> GrabLimitedVacanciesCount(VacancySearchRequest request, IProgress<double> progress,
            VacanciesWorkProgress? workProgress = default)
        {
            if (workProgress == null)
            {
                workProgress = new VacanciesWorkProgress();
            }

            await foreach (var vacancySearchPage in _apiService.SearchVacancies(request))
            {
                List<VacancySearchItem> vacanciesSearchResults = vacancySearchPage.Items;

                IEnumerable<VacancyEntity> vacancies =
                   vacanciesSearchResults.Select(_mappingService.MapVacancyEntityFromVacancyItem);

                await _dbService.InsertVacancies(vacancies.ToArray());

                workProgress.InsertedCount += vacancies.Count();

                IEnumerable<int> vacancyIds = vacancies.Select(vacancy => int.Parse(vacancy.Id));

                IEnumerable<VacancyDetail> vacancyDetails = await _apiService.GetVacancyDetails(vacancyIds);

                VacancyDetailDTO[] vacancyDetailDTOs = vacancyDetails
                    .Select(_mappingService.MapVacancyDetailDTOFromVacancyDetail)
                    .ToArray();

                await _dbService.InsertVacancyDetails(vacancyDetailDTOs);

                if (workProgress.TotalCount == default)
                {
                    workProgress.TotalCount = Math.Min(request.MaxResults, vacancySearchPage.Found);
                }

                progress?.Report(workProgress.TotalProgress);

            }
            return (int)workProgress.TotalCount;
        }


        public async Task<int> GrabVacancySearchResults(VacancySearchRequest request, IProgress<double> progress)
        {
            if (request.MaxResults <= _apiService.MaxSearchResults)
            {
                return await GrabLimitedVacanciesCount(request, progress);
            }

            int searchResultCount = await _apiService.GetSearchQueryResultsCount(request);

            int limit = new int[] { searchResultCount, request.MaxResults, MaxSearchResultsByQuery }
                                    .Min();

            TimeSpan interval = await ProbeInterval(request);
            DateTime toDate = DateTime.Now;
            var workProgress = new VacanciesWorkProgress { TotalCount = limit, InsertedCount = 0 };

            while (!workProgress.IsDone)
            {
                DateTime fromDate = toDate.Subtract(interval);
                request.DateFrom = fromDate;
                request.DateTo = toDate;
                await GrabLimitedVacanciesCount(request, progress, workProgress);
                toDate = fromDate.Subtract(TimeSpan.FromDays(1));
            }

            return (int)workProgress.InsertedCount;
        }
    }
}
