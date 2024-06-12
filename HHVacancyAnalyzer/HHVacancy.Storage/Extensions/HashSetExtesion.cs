namespace HHVacancy.Storage.Extensions
{
    public static class HashSetExtesion
    {
        /// <summary>
        /// Проверка существования элемента в множестве для значимых и ссылочных типов
        /// </summary>
        public static bool ExistsItem<T>(this HashSet<T> hashSet, T item)
        {
            Type t = typeof(T);
            bool isPrimitiveType = t.IsPrimitive || t.IsValueType || (t == typeof(string));

            if (isPrimitiveType)
                return hashSet.Contains(item);

            return hashSet.Any(hashSetItem => ObjectComparer.AreFieldsEqual(hashSetItem, item));
        }
    }
}
