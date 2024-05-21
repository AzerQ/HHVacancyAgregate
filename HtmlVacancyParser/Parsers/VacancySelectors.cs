namespace HHVacancyParser.Parsers
{
    public static class VacancySelectors
    {
        public const string VacancyName = "h1[data-qa='vacancy-title']";
        public const string CompanyRating = "div[data-qa='employer-review-small-widget-total-rating']";
        public const string WatchingPeopleCount = "span.vacancy-viewers-count";
        public const string CompanyName = "span[data-qa='bloko-header-2']";
        public const string CompanyAddress = "span[data-qa='vacancy-view-raw-address']";
        public const string RecommendationsPercent = "h1[data-qa='bloko-header-1']";
        public const string WorkKeyTags = "span[data-qa='bloko-tag__text']";
        public const string SalaryRange = "div[data-qa='vacancy-salary']";
        public const string RemoteWork = "//p[@data-qa='vacancy-view-employment-mode']//span[contains(text(),'удаленная работа')]";
        public const string VacancyDescription = "div.vacancy-description";
        public const string VacancyId = "a[data-qa='vacancy-company-name']";
    }
}
