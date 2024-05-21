using Fizzler.Systems.HtmlAgilityPack;
using HHVacancyParser.Models;
using HHVacancyParser.Utils;
using HtmlAgilityPack;
using OpenQA.Selenium;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace HHVacancyParser.Parsers
{
    public partial class VacancyParser : IDisposable
    {
        private IWebDriver _driver;

        #region DomLocators

        private readonly By VacancyNameLocator = By.CssSelector(VacancySelectors.VacancyName);
        private readonly By CompanyRatingLocator = By.CssSelector(VacancySelectors.CompanyRating);
        private readonly By WatchingPeopleCountLocator = By.CssSelector(VacancySelectors.WatchingPeopleCount);
        private readonly By CompanyNameLocator = By.CssSelector(VacancySelectors.CompanyName);
        private readonly By CompanyAddressLocator = By.CssSelector(VacancySelectors.CompanyAddress);
        private readonly By RecommendationsPercentLocator = By.CssSelector(VacancySelectors.RecommendationsPercent);
        private readonly By WorkKeyTagsLocator = By.CssSelector(VacancySelectors.WorkKeyTags);
        private readonly By SalaryRangeLocator = By.CssSelector(VacancySelectors.SalaryRange);
        private readonly By RemoteWorkLocator = By.CssSelector(VacancySelectors.RemoteWork);
        private readonly By VacancyDescriptionLocator = By.CssSelector(VacancySelectors.VacancyDescription);
        private readonly By VacancyIdLocator = By.CssSelector(VacancySelectors.VacancyId);

        #endregion
        const string InnerHtmlAttribute = "innerHTML";
         

        private HtmlDocument currentVacancyHtmlDocument;

        /// <summary>
        /// Initializes a new instance of the <see cref="VacancyParser"/> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        public VacancyParser(IWebDriver driver = null)
        {
            _driver = driver;
            currentVacancyHtmlDocument = new HtmlDocument();
        }

        private string GetElementText(By selector)
        {
            try
            {
                return _driver.FindElement(selector).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }

        private string GetElementHtml(By selector)
        {
            try
            {
                return _driver.FindElement(selector).GetAttribute("innerHTML");
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }



        /// <summary>
        /// Returns a collection of text values for all elements matching the specified selector.
        /// </summary>
        /// <param name="selector">The element  selenium selector.</param>
        /// <returns>A collection of text values for all elements matching the specified selector.</returns>
        private IEnumerable<string> GetElementsText(By selector)
        {
            return _driver.FindElements(selector).Select(element => element.Text);
        }

        /// <summary>
        /// Gets the text of an element, handling exceptions gracefully.
        /// </summary>
        /// <param name="cssSelector">The element css selector.</param>
        /// <param name="doc">The parsed DOM object</param>
        /// <returns>The text of the element, or an empty string if the element could not be found.</returns>
        private string GetElementText(string cssSelector, HtmlDocument doc = null)
        {
            doc ??= currentVacancyHtmlDocument;
            return doc.DocumentNode.QuerySelector(cssSelector)?.InnerText ?? string.Empty;
        }

        private string GetElementHtml(string cssSelector, HtmlDocument doc = null)
        {
            doc ??= currentVacancyHtmlDocument;
            return doc.DocumentNode.QuerySelector(cssSelector)?.InnerHtml ?? string.Empty;
        }

        /// <summary>
        /// Returns a collection of text values for all elements matching the specified selector.
        /// </summary>
        /// <param name="cssSelector">The element css selector.</param>
        /// <param name="doc">The parsed DOM object</param>
        /// <returns>A collection of text values for all elements matching the specified selector.</returns>
        private IEnumerable<string> GetElementsText(string cssSelector, HtmlDocument doc = null)
        {
            doc ??= currentVacancyHtmlDocument;
            return doc.DocumentNode.QuerySelectorAll(cssSelector)
                .Select(node => node?.InnerText ?? string.Empty);
        }

        /// <summary>
        /// Parses a vacancy from a given link (hh.ru) using Selenium.
        /// </summary>
        /// <param name="vacancyLink">The link of the vacancy to parse.</param>
        /// <returns>The parsed vacancy.</returns>

        //public Vacancy ParseVacancyFromLinkBySelenium(string vacancyLink)
        //{
        //    if (_driver == null)
        //        throw new NullReferenceException(nameof(_driver));

        //    _driver.Navigate().GoToUrl(vacancyLink);

        //    Company company = new Company()
        //    {
        //        Adress = GetElementText(CompanyAddressLocator),
        //        Name = GetElementText(CompanyNameLocator),
        //        RecommendationsPercent = ParseIntegerFromString(GetElementText(RecommendationsPercentLocator)),
        //        Rating = ParseFloatFromString(GetElementText(CompanyRatingLocator))
        //    };

        //    Vacancy vacancy = new Vacancy
        //    {
        //        Name = GetElementText(VacancyNameLocator),
        //        WatchingPeopleCount = ParseIntegerFromString(GetElementText(WatchingPeopleCountLocator)),
        //        WorkKeyTags = GetElementsText(WorkKeyTagsLocator).ToList(),
        //        HasRemoteWork = GetElementText(RemoteWorkLocator)
        //            .Contains("удаленная работа", StringComparison.InvariantCultureIgnoreCase),
        //        Company = company,
        //        DescriptionHtmlContent = GetElementHtml(VacancyDescriptionLocator),
        //        Id = ParseIntegerFromString(vacancyLink)
        //    };

        //    (vacancy.SalaryFrom, vacancy.SalaryTo, vacancy.SalaryIsWhite)
        //         = SalaryRange.FromSalaryString(GetElementText(SalaryRangeLocator));

        //    return vacancy;
        //}


        public async Task<Vacancy> ParseVacancyFromLinkAsync(string vacancyLink)
        {
            //_driver.Navigate().GoToUrl(vacancyLink);
            //WebDriverWait wait = new WebDriverWait(_driver, _driver.Manage().Timeouts().PageLoad);
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //wait.Until(c => c.FindElement(VacancyNameLocator));

            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13;
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(vacancyLink);
            string vacancyPageHtml = await response;

            // Vacancy vacancy = ParseVacancyFromHtml(vacancyPageHtml);
            // vacancy.Id = ParseIntegerFromString(vacancyLink);
            return null; //vacancy;
        }

        //public Vacancy ParseVacancyFromHtml(string htmlVacancyLayout)
        //{
        //    currentVacancyHtmlDocument.LoadHtml(htmlVacancyLayout);

        //    Company company = new Company
        //    {
        //        Adress = GetElementText(VacancySelectors.CompanyAddress),
        //        Name = GetElementText(VacancySelectors.CompanyName),
        //        RecommendationsPercent = ParseIntegerFromString(GetElementText(VacancySelectors.RecommendationsPercent)),
        //        Rating = ParseFloatFromString(GetElementText(VacancySelectors.CompanyRating))
        //    };

        //    Vacancy vacancy = new Vacancy
        //    {
        //        Name = GetElementText(VacancySelectors.VacancyName),
        //        WatchingPeopleCount = ParseIntegerFromString(GetElementText(VacancySelectors.WatchingPeopleCount)),
        //        WorkKeyTags = GetElementsText(VacancySelectors.WorkKeyTags).ToList(),
        //        HasRemoteWork = GetElementText(VacancySelectors.RemoteWork)
        //            .Contains("удаленная работа", StringComparison.InvariantCultureIgnoreCase),
        //        Company = company,
        //        DescriptionHtmlContent = GetElementHtml(VacancySelectors.VacancyDescription)
        //    };

        //    (vacancy.SalaryFrom, vacancy.SalaryTo, vacancy.SalaryIsWhite)
        //         = SalaryRange.FromSalaryString(GetElementText(VacancySelectors.SalaryRange));

        //    return vacancy;
        //}


        [GeneratedRegex("\\d+")]
        private static partial Regex IntNumRegex();

        [GeneratedRegex("-?[0-9]*\\.?[0-9]+")]
        private static partial Regex FloatNumRegex();

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}
