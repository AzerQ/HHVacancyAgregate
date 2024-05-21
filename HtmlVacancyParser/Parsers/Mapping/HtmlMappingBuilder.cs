using System.Linq.Expressions;
using System.Reflection;



namespace HHVacancyParser.Parsers.Mapping
{
    public class HtmlMappingBuilder<T> where T : class
    {
        private readonly HtmlQueryDictionary _queries;
        public readonly string TypeName = typeof(T).FullName ?? "";

        public HtmlMappingBuilder()
        {
            _queries = new();
        }

        private PropertyInfo GetProperty<P>(Expression<Func<T, P>> property)
        {
            var expression = (MemberExpression)property.Body;
            return expression.Member as PropertyInfo;
        }

        public HtmlMappingBuilder<T> LoadFromType(Type? type = default)
        {
            type ??= typeof(T);

            var typeProperties = type.GetProperties();

            foreach (var property in typeProperties)
            {
                HtmlMappingAttribute? htmlMappingAttribute = property.GetCustomAttribute<HtmlMappingAttribute>();
                MapIntoAttribute? mapIntoAttribute = property.GetCustomAttribute<MapIntoAttribute>();

                if (htmlMappingAttribute != null)
                {
                    var query = HtmlQuery.FromHtmlMappingAttribute(htmlMappingAttribute);
                    query.ResultType = property.PropertyType.IsCollection() ? ResultType.Collection : ResultType.SingleValue;
                    _queries.Add(query.Query, (property, query));
                }

                else if (mapIntoAttribute != null)
                {
                    Type propType = property.PropertyType;

                    if (type.IsClass && !propType.IsCollection())
                    {
                        LoadFromType(propType);
                    }
                }
            }

            return this;
        }

        public HtmlMappingBuilder<T> AddMapping<P>(Expression<Func<T, P>> property,
                                                HtmlQuery htmlQuery)
        {

            _queries.Add(htmlQuery.Query, (GetProperty(property), htmlQuery));
            return this;
        }

        public HtmlMappingBuilder<T> ChangeMapping<P>(Expression<Func<T, P>> property,
                                                       HtmlQuery htmlQuery)
        {
            _queries[htmlQuery.Query] = (GetProperty(property), htmlQuery);
            return this;
        }

        public HtmlQueryDictionary Build()
        {
            return _queries;
        }
    }


}
