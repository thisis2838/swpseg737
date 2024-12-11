using Newtonsoft.Json;

namespace HoaLacLaptopShop.Helpers
{
    public static class DictionaryHelpers
    {
        public static void Set<T>(this IDictionary<T, object?> dict, T key, object? value)
        {
            dict[key] = JsonConvert.SerializeObject(value);
        }
        public static E? Get<T, E>(this IDictionary<T, string> dict, T key)
        {
            return JsonConvert.DeserializeObject<E>(dict[key]);
        }
    }
}
