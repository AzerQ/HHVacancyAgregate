using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HHVacancy.Storage.Services.Abstractions
{
    public interface IJsonDbSerializer
    {
        ValueConverter<T, string> GetJsonValueConverter<T>();
    }
}
