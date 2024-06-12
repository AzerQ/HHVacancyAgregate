using HHVacancy.Core;
using HHVacancy.Core.Services.Abstractions;
using HHVacancy.Models.API.VacancySearch;

namespace HHVacancy.ConsoleApp
{

    public class Program
    {
        const int MaxSearchItemsSize = 100;

        public static IEnumerable<string> GetFromUserPrompt()
        {
            Console.Write("Введите текст для поиска вакансий на ресурсе hh.ru: ");
            string userPrompt = Console.ReadLine();
            yield return userPrompt;
        }

        public static IEnumerable<string> GetFromFile(string path)
        {
            return File.ReadAllLines(path);
        }


        static async Task Main(string[] args)
        {
            IVacancyGrabberService vacancyGrabberService =
                ServicesContainer.GetService<IVacancyGrabberService>();

            Progress<float> progress = new Progress<float>(percent => Console.WriteLine("{0} % complete", percent));

            var searchStrings = GetFromFile("SearchInputs.txt");

            foreach (var searchString in searchStrings)
            {
                var vacancySearchRequest = new VacancySearchRequest
                {
                    OnlyWithSalary = true,
                    Text = searchString,
                    MaxResults = MaxSearchItemsSize
                };

                int findedResults = await vacancyGrabberService
                    .GrabVacancySearchResults(vacancySearchRequest, progress);

                Console.WriteLine("Найденно и сохранено {0} записей по запросу: '{1}'", findedResults, searchString);

            }
        }


    }
}
