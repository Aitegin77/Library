using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common.Extensions
{
    public static class ObjectExtension
    {
        public static string ToJson<T>(this T obj) =>
            JsonSerializer.Serialize(obj, new JsonSerializerOptions()
            {
                WriteIndented = true
            });

        public static string ToJson<T>(this T obj, ReferenceHandler rh) =>
            JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                ReferenceHandler = rh,
            });

        public static T? FromJson<T>(this string obj) where T : class =>
            obj.IsNullOrEmpty() ? null : JsonSerializer.Deserialize<T>(obj);

        public static T? FromJson<T>(this string obj, ReferenceHandler rh) where T : class =>
            obj.IsNullOrEmpty() ? null
                : JsonSerializer.Deserialize<T>(obj, new JsonSerializerOptions
                {
                    ReferenceHandler = rh,
                });
    }
}
