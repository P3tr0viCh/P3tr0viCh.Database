using P3tr0viCh.Utils.Extensions;

namespace P3tr0viCh.Database
{
    public class Query
    {
        public string Sql { get; set; } = string.Empty;
        public string Fields { get; set; } = string.Empty;
        public string Table { get; set; } = string.Empty;
        public string Where { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;
        public int Limit { get; set; } = 0;
        public int Offset { get; set; } = 0;

        public override string ToString()
        {
            string sql;

            if (Sql.IsEmpty())
            {
                if (Fields.IsEmpty())
                {
                    Fields = "*";
                }

                sql = $"SELECT {Fields}";
            }
            else
            {
                sql = Sql;
            }

            sql = sql.JoinExcludeEmpty(" FROM ", Table);
            sql = sql.JoinExcludeEmpty(" WHERE ", Where);
            sql = sql.JoinExcludeEmpty(" GROUP BY ", Group);
            sql = sql.JoinExcludeEmpty(" ORDER BY ", Order);

            if (Limit > 0)
            {
                sql = sql.JoinExcludeEmpty(" LIMIT ", Limit.ToString());
            }

            if (Offset > 0)
            {
                sql = sql.JoinExcludeEmpty(" OFFSET ", Offset.ToString());
            }

            sql += ";";

            return sql;
        }
    }
}