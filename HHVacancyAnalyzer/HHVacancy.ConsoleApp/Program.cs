using HHVacancy.Core;
using HHVacancy.Core.Services.Abstractions;
using HHVacancy.Models.API.VacancySearch;
using Luna.ConsoleProgressBar;
using System.Diagnostics;

namespace HHVacancy.ConsoleApp
{

    public class Program
    {
        const int MaxSearchItemsSize = 5_000;

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

        private static async Task SearchQuery(IVacancyGrabberService vacancyGrabberService, string query, bool searchOnlyWithSalary)
        {
            Stopwatch sw = Stopwatch.StartNew();

            using (var progressBar = new ConsoleProgressBar())
            {

                Console.Write("Поиск вакансий по запросу {0} ", query);
                var vacancySearchRequest = new VacancySearchRequest
                {
                    OnlyWithSalary = searchOnlyWithSalary,
                    Text = query,
                    MaxResults = MaxSearchItemsSize,
                    ResponsesCountEnabled = true
                };

                int findedResults = await vacancyGrabberService
                    .GrabVacancySearchResults(vacancySearchRequest, progressBar);

                double totalSecondsEllapsed = sw.Elapsed.TotalSeconds;

                double recordsPerSecond = Math.Round(findedResults / totalSecondsEllapsed, 2);

                Console.WriteLine();
                Console.WriteLine("Найденно и сохранено {0} записей ({1} элем. / с ) по запросу: '{2}'",
                    findedResults, recordsPerSecond, query);
                Console.WriteLine();
            }

        }

        static async Task Main(string[] args)
        {
            IVacancyGrabberService vacancyGrabberService =
                ServicesContainer.GetService<IVacancyGrabberService>();

            Progress<float> progress = new Progress<float>(percent => Console.WriteLine("{0} % complete", percent));

            IEnumerable<string> searchStrings = GetFromUserPrompt(); //GetFromFile("SearchInputs.txt");

            Console.Write("Вы хотите искать вакансии только с указанной З/П (Д/Н)?: ");

            string input = Console.ReadLine().Trim().ToUpper();

            bool onlyWithSalary = input.StartsWith("Д");

            foreach (string searchString in searchStrings)
            {
                await SearchQuery(vacancyGrabberService, searchString, onlyWithSalary);
            }
        }


    }
}
