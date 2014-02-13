using System.Collections.Generic;
using System.Data;

namespace System
{
    public static class IDataReaderTools
    {
        public static IEnumerable<T> List<T>(this IDataReader reader) where T : new()
        {
            var properties = typeof(T).GetProperties();

            while (reader.Read())
            {
                var element = new T();

                foreach (var f in properties)
                {
                    var o = reader[f.Name];
                    if (o.GetType() != typeof(DBNull))
                        f.SetValue(element, o, null);
                }
                yield return element;
            }
        }

        public static T Firt<T>(this IDataReader reader) where T : new()
        {
            var properties = typeof(T).GetProperties();
            var element = new T();

            while (reader.Read())
            {
                foreach (var f in properties)
                {
                    var o = reader[f.Name];
                    if (o.GetType() != typeof(DBNull))
                        f.SetValue(element, o, null);
                }
                return element;
            }

            return default(T);
        }
    }
}
