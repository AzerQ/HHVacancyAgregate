using HHVacancy.Core.Data.Models.VacancySearch;
using HHVacancy.Core.Data.Services;

namespace HHApi.App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IVacancyService service = new VacancyService();
            var vacancyData = await service.GetVacancyById(99955831);

            var vacancySearchResult = await service.SearchVacancies(new VacancySearchRequest
            {
                Text = "C# разработчик",
                Page = 0,
                PerPage = 30
            });
        }
    }
}
