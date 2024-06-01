using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HHVacancy.Core.Data.Services.DataConverters
{
    public interface IJsonDbSrializer
    {
        ValueConverter<T, string> GetJsonValueConverter<T>();
    }
}
