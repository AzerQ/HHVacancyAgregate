using HHVacancy.Core;
using HHVacancy.Core.Services.Abstractions;
using HHVacancy.Models.API.VacancySearch;

namespace HHVacancy.ConsoleApp
{

    public class Program
    {


        static async Task Main(string[] args)
        {
            IVacancyGrabberService vacancyGrabberService =
                ServicesContainer.GetService<IVacancyGrabberService>();

            Progress<float> progress = new Progress<float>(percent => Console.WriteLine("{0} % complete", percent));

            while (true)
            {
                Console.Write("Введите текст для поиска вакансий на ресурсе hh.ru: ");
                string userPrompt = Console.ReadLine();

                var vacancySearchRequest = new VacancySearchRequest
                {
                    OnlyWithSalary = true,
                    Text = userPrompt,
                    MaxResults = 300
                };

                int findedResults = await vacancyGrabberService
                    .GrabVacancySearchResults(vacancySearchRequest, progress);

                Console.WriteLine("Найденно и сохранено {0} записей по запросу: '{1}'", findedResults, userPrompt);
            }

        }


    }
}
