using System.Text.Json;

namespace Core_MVCApp.CustomSessions
{
    public static class CLRObjectSessionExtensions
    {
        public static void SetCLRObject<T>(this ISession session, string key, T value)
        {
            var data = JsonSerializer.Serialize(value);
            session.SetString(key, data);
        }

        public static T GetCLRObject<T>(this ISession session, string key)
        { 
            var stringData = session.GetString(key);

            T data = JsonSerializer.Deserialize<T>(stringData);
            if (data == null)
                return default(T); // Return DEfault Instance of the CLR Object

            return data;

        }
    }
}
