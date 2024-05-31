using VacancyFullModel = HHVacancy.Core.Data.Models.Vacancy.Vacancy;
using HHVacancy.Core.Data.Models.VacancySearch;
using HHVacancy.Core.Data.Services.API;

namespace Vacancy.Core.Test
{
    [TestClass]
    public class VacancyServiceUnitTest
    {
        private static IVacancyHHService _vacancyService;

        static VacancyServiceUnitTest()
        {
            _vacancyService = GetVacancyService();
        }

        private static VacancySearchRequest GetSampleVacancySearchRequest() =>
            new VacancySearchRequest
            {
                Text = "Экономист",
                OnlyWithSalary = true
            };

        private static IVacancyHHService GetVacancyService() => new VacancyHHService();

        /// <summary>
        /// Выбрать список случайных идентификаторов вакансий
        /// </summary>
        /// <param name="count">Кол-во должно быть меньше или равно 100</param>
        /// <returns>Список существующих идентификаторов вакансий</returns>
        private static IEnumerable<int> GetRandomVacancyIds(byte count)
        {
            VacancySearchRequest request = GetSampleVacancySearchRequest();
            request.PerPage = count;

            VacancySearchResult searchPageResult = _vacancyService.GetVacancySearchPage(request)
                .GetAwaiter()
                .GetResult();

            return searchPageResult.Items.Select(x => int.Parse(x.Id));
        }

        public static IEnumerable<object[]> GetTenRandomVacancyIds()
        {

            IEnumerable<int> data = GetRandomVacancyIds(10);
            return data.Select(id => new object[] { id });
        }

        public VacancyServiceUnitTest()
        {
        }

        [DynamicData(nameof(GetTenRandomVacancyIds), DynamicDataSourceType.Method)]
        [TestMethod]
        [TestCategory("GetVacancyByID")]
        public async Task TestGetVacancyByID(int vacancyID)
        {
            VacancyFullModel vacancyFullModel = await _vacancyService.GetVacancyById(vacancyID);

            Assert.IsNotNull(vacancyFullModel, "Модель вакансии имеет значение null!");
            Assert.IsNotNull(vacancyFullModel.Name, "Имя вакансии имеет значение null!");
            Assert.IsNotNull(vacancyFullModel.Experience, "Поле 'опыт вакансии' имеет значение null!");

        }

        [DataRow(1)]
        [DataRow(10)]
        [DataRow(50)]
        [DataRow(100)]
        [TestMethod]
        [TestCategory("GetVacancySearchPage")]
        public async Task TestGetVacancySearchPage(int pageSize)
        {
            VacancySearchRequest request = GetSampleVacancySearchRequest();
            request.PerPage = pageSize;

            VacancySearchResult vacancySearchPageModel = await _vacancyService
                                .GetVacancySearchPage(request);

            Assert.IsNotNull(vacancySearchPageModel, "Результат поиска ваканси имеет значение null!");
            Assert.AreNotEqual(0, vacancySearchPageModel.Found, "Поле с кол-вом найденных значений = 0!");
            Assert.AreNotEqual(0, vacancySearchPageModel.Pages, "Поле с кол-вом страниц = 0!");
            Assert.AreNotEqual(0, vacancySearchPageModel.Items.Count, "Не найденны данные по запросу!");
        }
        [DataRow("Программист 1С")]
        [DataRow("Программист Java")]
        [DataRow("Системный администратор")]
        [DataRow("Специалист информационной безопасности")]
        [TestMethod]
        [TestCategory("GetVacancyFullSearchResults")]
        public async Task TestVacancyFullSearch(string searchString)

        {
            var vacancySearchRequest = new VacancySearchRequest
            {
                Text = searchString
            };

            var fullSearchResults = new List<VacancySearchResult>(1000);


            await foreach (var vacancyResult in
                _vacancyService.SearchVacancies(vacancySearchRequest))
            {
                fullSearchResults.Add(vacancyResult);
            }

            bool listHasNullItems = fullSearchResults.All(element => element != null);
            int totalItemsCount = fullSearchResults.Select(page=>page.Items.Count).Sum();
            int exceptedItemsCount = Math.Min(fullSearchResults[0].Found, 2000);

            Assert.AreNotEqual(0, fullSearchResults.Count, "Данные не были полученны при поиске вакансий!");
            Assert.AreEqual(exceptedItemsCount, totalItemsCount, "Полученны не все данные поиска!");
            Assert.IsTrue(listHasNullItems, "Среди результатов запроса есть пустые элементы!");
           

        }

    }
}