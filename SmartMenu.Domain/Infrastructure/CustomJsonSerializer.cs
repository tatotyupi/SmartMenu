using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SmartMenu.Domain.Infrastructure
{
    public class CustomJsonSerializer
    {
        public string SerializeObject(object obj)
        {

            JsonSerializerOptions options = new JsonSerializerOptions();
            options
                .Converters
                .Add(new JsonStringEnumConverter());
            return System.Text.Json.JsonSerializer.Serialize(obj, options);


        }

        public T DesrializeObject<T>(string json)
            where T : class
        {

            JsonSerializerOptions options = new JsonSerializerOptions();
            options
                .Converters
                .Add(new JsonStringEnumConverter());

            return (T)JsonSerializer.Deserialize(json, typeof(T), options);
        }

        public object DesrializeObject(string json, Type returnType)
        {

            JsonSerializerOptions options = new JsonSerializerOptions();
            options
                .Converters
                .Add(new JsonStringEnumConverter());

            return JsonSerializer.Deserialize(json, returnType, options);
        }

    }
}
