using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Common.Helper
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            if (value == null)
            {
                session.SetString(key, null);
            }
            else
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
