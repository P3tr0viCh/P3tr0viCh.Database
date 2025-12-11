using P3tr0viCh.Utils;

namespace P3tr0viCh.Database
{
    public class Query
    {
        public string fields = string.Empty;
        public string table = string.Empty;
        public string where = string.Empty;
        public string group = string.Empty;
        public string order = string.Empty;
        public int limit = 0;
        public int offset = 0;

        public string Select()
        {
            if (fields.IsEmpty())
            {
                fields = "*";
            }

            var sql = "SELECT " + fields;

            sql = sql.JoinExcludeEmpty(" FROM ", table);
            sql = sql.JoinExcludeEmpty(" WHERE ", where);
            sql = sql.JoinExcludeEmpty(" GROUP BY ", group);
            sql = sql.JoinExcludeEmpty(" ORDER BY ", order);

            if (limit > 0)
            {
                sql = sql.JoinExcludeEmpty(" LIMIT ", limit.ToString());
            }

            if (offset > 0)
            {
                sql = sql.JoinExcludeEmpty(" OFFSET ", offset.ToString());
            }

            return sql;
        }
    }
}