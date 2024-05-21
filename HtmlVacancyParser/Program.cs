global using HtmlQueryDictionary = System.Collections.Generic.Dictionary<string, (System.Reflection.PropertyInfo info, HHVacancyParser.Parsers.Mapping.HtmlQuery query)>;
using HHVacancyParser.Models;
using HHVacancyParser.Parsers;
using HHVacancyParser.Parsers.Mapping;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace HHVacancyParser
{
    internal class Program
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(8);
            return webDriver;
        }

        public static VacancyParser InitializeParserWithDriver()
        {
            return new VacancyParser(GetDriver());
        }

        public static VacancyParser InitializeParser()
        {
            return new VacancyParser();
        }

        public static async Task Main(string[] args)
        {

            var Data = new HtmlMappingBuilder<Vacancy>().LoadFromType().Build();
            //using (VacancyParser vacancyParser = InitializeParser())
            //{
            //    var vacancy = await vacancyParser.ParseVacancyFromLinkAsync("https://spb.hh.ru/vacancy/93610273?hhtmFrom=favorite_vacancy_list");
            //}
        }
    }
}
