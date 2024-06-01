using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace HHVacancy.Core.Data.Services.DataConverters
{
    public class JsonDbSerializer :IJsonDbSrializer
    {
        private readonly JsonSerializerOptions _serializerOptions =
            new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

        private string JsonSerialize(object obj) => JsonSerializer.Serialize(obj, _serializerOptions);

        private T? JsonDeserialize<T>(string str) => JsonSerializer.Deserialize<T>(str, _serializerOptions);


        public ValueConverter<T, string> GetJsonValueConverter<T>() =>
            new ValueConverter<T, string>(
                    v => JsonSerialize(v),
                    v => JsonDeserialize<T>(v)
            );
    }
}
