using P3tr0viCh.Utils;
using System;
using System.Linq;

namespace P3tr0viCh.Database
{
    public class Sql
    {
        public static long NewId = 0;

        public static string TableName<T>()
        {
            dynamic tableattr = typeof(T).GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");

            if (tableattr != null) return tableattr.Name;

            return string.Empty;
        }

        public static string FieldName(string name, string table = null, string alias = null)
        {
            var sql = name.ToLower();

            if (!table.IsEmpty()) sql = table + "." + sql;

            if (!alias.IsEmpty()) sql += " AS " + alias;

            return sql;
        }

        private readonly static string DataQuery = "QUERY";

        public static void ExceptionAddQuery(Exception e, string query)
        {
            e.Data.Add(DataQuery, query);
        }

        public static string ExceptionGetQuery(Exception e)
        {
            return Convert.ToString(e?.Data[DataQuery]);
        }
    }
}