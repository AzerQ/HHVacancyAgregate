using HHVacancyParser.Parsers.Mapping;
using HHVacancyParser.Parsers;
using System.ComponentModel.DataAnnotations;

namespace HHVacancyParser.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [HtmlMapping(Query = VacancySelectors.RecommendationsPercent, Type = QueryType.Css)]
        public int RecommendationsPercent { get; set; }


        [HtmlMapping(Query = VacancySelectors.CompanyRating, Type = QueryType.Css)]
        public float Rating { get; set; }


        [HtmlMapping(Query = VacancySelectors.CompanyName, Type = QueryType.Css)]
        public string Name { get; set; }


        [HtmlMapping(Query = VacancySelectors.CompanyAddress, Type = QueryType.Css)]
        public string Adress { get; set; }
    }
}
