﻿using Flurl.Http.Configuration;
using HHVacancy.ApiClient.Converters;
using System.IO;
using System.Text.Json;

namespace HHVacancy.ApiClient.Services.Implementations;

public class CorrectDateSerializer : ISerializer
{
    private readonly JsonSerializerOptions _options;

    public CorrectDateSerializer()
    {
        _options = new JsonSerializerOptions
        {
            Converters = {
                    new DateTimeConverter()
                },
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };
    }

    public T Deserialize<T>(string s) => JsonSerializer.Deserialize<T>(s, _options);

    public T Deserialize<T>(Stream stream)
    {
        return JsonSerializer.Deserialize<T>(stream, _options);
    }

    public string Serialize(object obj) => JsonSerializer.Serialize(obj, _options);

}

