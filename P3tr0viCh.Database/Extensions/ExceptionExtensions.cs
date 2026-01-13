using System;

namespace P3tr0viCh.Database.Extensions
{
    public static class ExceptionExtensions
    {
        private readonly static string DataQuery = "QUERY";

        public static void AddQuery(this Exception e, string query)
        {
            e.Data.Add(DataQuery, query);
        }

        public static string GetQuery(this Exception e)
        {
            return Convert.ToString(e?.Data[DataQuery]);
        }
    }
}