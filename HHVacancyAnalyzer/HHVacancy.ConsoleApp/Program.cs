using HHVacancy.ApiClient.Services.Abstractions;
using HHVacancy.Core;
using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Storage.Services.Abstractions;

namespace HHVacancy.ConsoleApp
{

    public class Program
    {
        static async Task AddUserVacancySearchResultsToDB(string vacancySearchText)
        {
            var apiService = ServicesContainer.GetService<IVacancyApiService>();
            var mappingSerivce = ServicesContainer.GetService<IVacancyMappingService>();
            var storageService = ServicesContainer.GetService<IVacancyDbService>();

            var vacancySearchRequest = new VacancySearchRequest()
            {
                Text = vacancySearchText
            };

            int insertedItemsCount = 0;

            await foreach (var vacancySearchPage in apiService.SearchVacancies(vacancySearchRequest))
            {

                IEnumerable<VacancyEntity> dbEntities =
                    vacancySearchPage.Items.Select(mappingSerivce.MapFromVacancyItem);

                await storageService.InsertVacancies(dbEntities.ToArray());

                insertedItemsCount += dbEntities.Count();

                Console.WriteLine("Добавление страницы {0} ({1}/{2} записей)",
                    vacancySearchPage.Page + 1, insertedItemsCount, vacancySearchPage.Found);
            }

            Console.WriteLine("Все записи по запросу '{0}' добавленны в хранилище!", vacancySearchText);

        }

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите текст для поиска вакансий на ресурсе hh.ru: ");
                string userPrompt = Console.ReadLine();
                await AddUserVacancySearchResultsToDB(userPrompt);
            }

        }


    }
}
