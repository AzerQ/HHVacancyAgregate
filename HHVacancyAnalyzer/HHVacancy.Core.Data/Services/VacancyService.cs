using Flurl;
using Flurl.Http;
using HHVacancy.Core.Data.Converters;
using HHVacancy.Core.Data.Models.Vacancy;
using HHVacancy.Core.Data.Models.VacancySearch;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HHVacancy.Core.Data.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly string _baseUrl;

        private void SetupFlurl()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new DateTimeConverter() }
            };

            FlurlHttp.Clients.WithDefaults(builder =>
                     builder.WithSettings(settings =>
                        {
                            settings.JsonSerializer = new CorrectDateSerializer();
                        }));
        }


        public VacancyService(string baseUrl = default)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                _baseUrl = "https://api.hh.ru";
            }

            SetupFlurl();
        }

        public async Task<Vacancy> GetVacancyById(int id)
        {

            var serverResponse = await _baseUrl.AppendPathSegment("vacancies")
                     .AppendPathSegment(id)
                     .AppendQueryParam("locale", "RU")
                     .AppendQueryParam("host", "hh.ru")
                     .WithHeader("HH-User-Agent", "HHWorkTagsAgregate")
                     .SendAsync(HttpMethod.Get);

            return await serverResponse.GetJsonAsync<Vacancy>();

        }

        public async Task<VacancySearchResult> SearchVacancies(VacancySearchRequest vacancySearchRequest)
        {
            var queryParams = vacancySearchRequest.ToDictionary();

            var serverResponse = await _baseUrl.AppendPathSegment("vacancies")
                                        .SetQueryParams(queryParams)
                                        .WithHeader("HH-User-Agent", "HHWorkTagsAgregate")
                                        .SendAsync(HttpMethod.Get);

            return await serverResponse.GetJsonAsync<VacancySearchResult>();
        }
    }
}
