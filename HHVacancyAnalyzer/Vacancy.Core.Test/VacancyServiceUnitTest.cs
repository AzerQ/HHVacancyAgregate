using VacancyFullModel = HHVacancy.Core.Data.Models.Vacancy.Vacancy;
using HHVacancy.Core.Data.Models.VacancySearch;
using HHVacancy.Core.Data.Services;

namespace Vacancy.Core.Test
{
    [TestClass]
    public class VacancyServiceUnitTest
    {
        private static IVacancyService _vacancyService;

        static VacancyServiceUnitTest()
        {
            _vacancyService = GetVacancyService();
        }

        private static VacancySearchRequest GetSampleVacancySearchRequest() =>
            new VacancySearchRequest
            {
                Text = "���������",
                OnlyWithSalary = true
            };

        private static IVacancyService GetVacancyService() => new VacancyService();

        /// <summary>
        /// ������� ������ ��������� ��������������� ��������
        /// </summary>
        /// <param name="count">���-�� ������ ���� ������ ��� ����� 100</param>
        /// <returns>������ ������������ ��������������� ��������</returns>
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

            Assert.IsNotNull(vacancyFullModel, "������ �������� ����� �������� null!");
            Assert.IsNotNull(vacancyFullModel.Name, "��� �������� ����� �������� null!");
            Assert.IsNotNull(vacancyFullModel.Experience, "���� '���� ��������' ����� �������� null!");

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

            Assert.IsNotNull(vacancySearchPageModel, "��������� ������ ������� ����� �������� null!");
            Assert.AreNotEqual(0, vacancySearchPageModel.Found, "���� � ���-��� ��������� �������� = 0!");
            Assert.AreNotEqual(0, vacancySearchPageModel.Pages, "���� � ���-��� ������� = 0!");
            Assert.AreNotEqual(0, vacancySearchPageModel.Items.Count, "�� �������� ������ �� �������!");
        }
        [DataRow("����������� 1�")]
        [DataRow("����������� Java")]
        [DataRow("��������� �������������")]
        [DataRow("���������� �������������� ������������")]
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

            Assert.AreNotEqual(0, fullSearchResults.Count, "������ �� ���� ��������� ��� ������ ��������!");
            Assert.AreEqual(exceptedItemsCount, totalItemsCount, "��������� �� ��� ������ ������!");
            Assert.IsTrue(listHasNullItems, "����� ����������� ������� ���� ������ ��������!");
           

        }

    }
}