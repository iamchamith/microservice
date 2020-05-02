using App.SharedKernel.Exception;
using App.SharedKernel.Utilities;
using Newtonsoft.Json;

namespace App.SharedKernel.Extension
{
    public static class JsonExtension
    {
        static JsonSerializerSettings _jsonSerializerDefaultSetting;
        static JsonExtension()
        {
            _jsonSerializerDefaultSetting = new JsonSerializerSettings
            {
                ContractResolver = new JsonPrivateSetterResolver()
            };
        }
        public static T ToObject<T>(this string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString, _jsonSerializerDefaultSetting);
            }
            catch (System.Exception)
            {
                throw new BadRequestException($"Cannot convert {jsonString} to {typeof(T)}");
            }

        }
        public static string ToJsonString<T>(this T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (System.Exception)
            {
                throw new BadRequestException($"Cannot convert {typeof(T)} to string");
            }

        }
    }
}
