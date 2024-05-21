using System.ComponentModel.DataAnnotations;

namespace HHVacancyParser.Parsers.Mapping
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HtmlMappingAttribute : Attribute
    {
        [Required]
        public  string Query { get; set; }

        [Required]
        public QueryType Type { get; set; }

        public ValueType ValueGetSemantics { get; set; } = ValueType.Text;

        public string?  AttributeName { get; set; }

        public HtmlMappingAttribute() { }

        public HtmlMappingAttribute(string query, QueryType type, ValueType valueGetSemantics, string? attributeName)
        {
            Query = query ?? throw new ArgumentNullException(nameof(query));
            Type = type;
            ValueGetSemantics = valueGetSemantics;
            AttributeName = attributeName;
        }
    }

    public enum  QueryType
    {
        Xpath,
        Css
    }

    public enum ValueType
    {
        Text,
        Attribute
    }

    public enum ResultType
    {
        SingleValue,
        Collection
    }

    public class HtmlQuery
    {
        public HtmlQuery(string query, QueryType type, ValueType valueGetSemantics, string? attributeName)
        {
            Query = query;
            Type = type;
            ValueGetSemantics = valueGetSemantics;
            AttributeName = attributeName;
        }

        [Required]
        public string Query { get; set; }

        [Required]
        public QueryType Type { get; set; }

        public ValueType ValueGetSemantics { get; set; } = ValueType.Text;

        public string? AttributeName { get; set; }

        public ResultType ResultType { get; set; }

        public static HtmlQuery FromHtmlMappingAttribute(HtmlMappingAttribute value)
        {
            return new HtmlQuery(value.Query,value.Type, value.ValueGetSemantics, value.AttributeName);
        }
    }
    
    public class HtmlQueryResult
    {
        public HtmlQueryResult()
        {
            RawResults = new List<string>();
        }

        public string? RawResult { get; set; }

        public List<string> RawResults { get; set; }

    }
}
