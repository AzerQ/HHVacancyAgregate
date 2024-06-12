using System.Reflection;

namespace HHVacancy.Storage.Extensions
{
    public static class ObjectComparer
    {
        public static bool AreFieldsEqual<T>(T obj1, T obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                return false;
            }

            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            var type = typeof(T);

            //Проверяем поля
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                var value1 = field.GetValue(obj1);
                var value2 = field.GetValue(obj2);

                if (!Equals(value1, value2))
                {
                    return false;
                }
            }

            // Проверяем свойства
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                // Проверяем, можно ли получить значение свойства (некоторые свойства могут быть только для записи)
                if (property.CanRead)
                {
                    var value1 = property.GetValue(obj1);
                    var value2 = property.GetValue(obj2);

                    if (!Equals(value1, value2))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
