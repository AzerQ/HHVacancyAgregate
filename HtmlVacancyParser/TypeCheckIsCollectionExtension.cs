namespace HHVacancyParser
{
    public static class TypeCheckIsCollectionExtension
    {
        public static bool IsCollection(this Type type)
        {
          return type.GetInterfaces().Any(i => i.Name.Contains("IEnumerable"));
        }
    }
}
