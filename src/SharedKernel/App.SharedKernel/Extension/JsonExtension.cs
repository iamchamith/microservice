using App.SharedKernel.Exception;
using Newtonsoft.Json;

namespace App.SharedKernel.Extension
{
    public static class JsonExtension
    {
        public static T ToObject<T>(this string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (System.Exception)
            {
                throw new BadRequestException($"Cannot convert {jsonString} to {typeof(T)}");
            }

        }
        public static string ToString<T>(this T obj)
        {
            try
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            }
            catch (System.Exception)
            {
                throw new BadRequestException($"Cannot convert {typeof(T)} to string");
            }

        }
    }
}
