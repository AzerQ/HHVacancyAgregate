﻿using Dumpify;
using HHVacancy.Core.Data.Models.VacancySearch;
using HHVacancy.Core.Data.Services;
using System.Diagnostics;

namespace HHApi.App
{
    public class TestHHApi
    {
        IVacancyHHService vacancyService = new VacancyHHService();

        IVacancyMappingService vacancyMappingService = new VacancyMappingService();

        public TestHHApi()
        {
        }


        private VacancySearchRequest GetSampleRequest() =>
            new VacancySearchRequest
            {
                Text = "C# разработчик удаленно",
                OnlyWithSalary = true
            };


        public async Task TestGetVacancyAsync()
        {
            int id = 99955831;
            var model = await vacancyService.GetVacancyById(id);
            model.DumpConsole();
        }

        public async Task TestGetVacancySearchPageAsync()
        {

            var model = await vacancyService.GetVacancySearchPage(GetSampleRequest());
            model.DumpConsole();
        }

        public async Task TestVacancyFullSearchAsync()
        {
            var fullSearchResults = new List<VacancyItem>(1000);

            Stopwatch sw = Stopwatch.StartNew();

            await foreach (var vacancyResult in vacancyService.SearchVacancies(GetSampleRequest()))
            {
                Console.WriteLine("Items on page {1} (Total items {0})", vacancyResult.Found, vacancyResult.Page);
                fullSearchResults.AddRange(vacancyResult.Items);
                var res = vacancyMappingService.MapFromVacancyItem(vacancyResult.Items[0]);
            }

            sw.Stop();
            sw.Elapsed.DumpConsole();
        }
    }

    public class Program
    {


        static async Task Main(string[] args)
        {
            TestHHApi testHHApi = new ();

            await testHHApi.TestGetVacancyAsync();
            await testHHApi.TestGetVacancySearchPageAsync();
            await testHHApi.TestVacancyFullSearchAsync();
            Console.ReadLine();
        }
    }
}
