using HHVacancy.ApiClient.Services.Abstractions;
using HHVacancy.Core;
using HHVacancy.Core.Services.Abstractions;
using HHVacancy.Models.API.VacancySearch;
using HHVacancy.Models.DB.Entities;
using HHVacancy.Storage.Services.Abstractions;

namespace HHVacancy.ConsoleApp
{

    public class Program
    {


        static async Task Main(string[] args)
        {
            IVacancyGrabberService vacancyGrabberService = 
                ServicesContainer.GetService<IVacancyGrabberService>();

            while (true)
            {
                Console.Write("Введите текст для поиска вакансий на ресурсе hh.ru: ");
                string userPrompt = Console.ReadLine();

                var vacancySearchRequest = new VacancySearchRequest
                {
                    OnlyWithSalary = true,
                    Text = userPrompt,
                    MaxResults = 150
                };

                int findedResults = await vacancyGrabberService
                    .GrabVacancySearchResults(vacancySearchRequest);

                Console.WriteLine("Найденно и сохранено {0} записей по запросу: '{1}'", findedResults, userPrompt);
            }

        }


    }
}
