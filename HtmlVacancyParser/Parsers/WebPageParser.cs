using HHVacancyParser.Parsers.Mapping;
using System.Reflection;

namespace HHVacancyParser.Parsers
{
    public abstract class WebPageParser<T>
    {
        private StringTypeConverter Converter { get; set; }

        private HtmlQueryDictionary Queries { get; set; }

        public abstract T Parse(string url);

        public abstract HtmlQueryResult ProcessHtmlQuery(HtmlQuery htmlQuery);       

    }
}
