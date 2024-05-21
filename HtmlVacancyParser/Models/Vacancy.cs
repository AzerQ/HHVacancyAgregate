using HHVacancyParser.Parsers;
using HHVacancyParser.Parsers.Mapping;
using HHVacancyParser.Utils;
using System.ComponentModel.DataAnnotations;

namespace HHVacancyParser.Models
{
    public class Vacancy
    {
        public Vacancy()
        {
            Company = new();
            WorkKeyTags = new();
        }

        [Key]
        public int Id { get; set; }

        [HtmlMapping(Query = VacancySelectors.VacancyName, Type = QueryType.Css)]
        public string Name { get; set; }

        [HtmlMapping(Query = VacancySelectors.WatchingPeopleCount, Type = QueryType.Css)]
        public int WatchingPeopleCount { get; set; }

        [MapInto]
        public Company Company { get; set; }

        [HtmlMapping(Query = VacancySelectors.WorkKeyTags, Type = QueryType.Css)]
        public List<string> WorkKeyTags { get; set; }

        private string _salaryString;

        [HtmlMapping(Query = VacancySelectors.SalaryRange, Type = QueryType.Css)]
        public string SalaryString { get => _salaryString; set
            {
                _salaryString = value;
                (SalaryFrom, SalaryTo, SalaryIsWhite) = SalaryRange.FromSalaryString(value);
            }
        }

        public int SalaryFrom { get; set; }

        public int SalaryTo { get; set; }

        public bool SalaryIsWhite { get; set; }

        [HtmlMapping(Query = VacancySelectors.RemoteWork, Type = QueryType.Xpath)]
        public bool HasRemoteWork { get; set; }

        [HtmlMapping(Query = VacancySelectors.VacancyDescription, Type = QueryType.Css)]
        public string DescriptionHtmlContent { get; set; } 
    }

}

