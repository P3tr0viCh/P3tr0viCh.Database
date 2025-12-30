using Dapper;
using Dapper.Contrib.Extensions;
using P3tr0viCh.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;

namespace P3tr0viCh.Database
{
    public static class DbConnectionExtensions
    {
        [Conditional("DEBUG")]
        private static void DebugWriteSql(string sql, object param, string memberName)
        {
#if DEBUG
            DebugWrite.Line(sql.SingleLine(), memberName);

            if (param != null)
            {
                DebugWrite.Line($"params: {param}", memberName);
            }
#endif
        }

        public static async Task ListItemSaveAsync<T>(this DbConnection connection, T value, DbTransaction transaction = null) where T : BaseId
        {
            if (value.Id == Sql.NewId)
            {
                await connection.InsertAsync(value, transaction);
            }
            else
            {
                await connection.UpdateAsync(value, transaction);
            }
        }

        public static async Task ListItemSaveAsync<T>(this DbConnection connection, IEnumerable<T> values, DbTransaction transaction = null) where T : BaseId
        {
            foreach (var value in values)
            {
                await ListItemSaveAsync(connection, value, transaction);
            }
        }

        public static async Task ListItemSaveAsync<T>(this DbConnection connection, IEnumerable<T> values) where T : BaseId
        {
            await connection.OpenAsync();

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    await ListItemSaveAsync(connection, values, transaction);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static async Task ListItemDeleteAsync<T>(this DbConnection connection, T value, DbTransaction transaction = null) where T : BaseId
        {
            await connection.DeleteAsync(value, transaction);
        }

        public static async Task ListItemDeleteAsync<T>(this DbConnection connection, IEnumerable<T> values, DbTransaction transaction = null) where T : BaseId
        {
            foreach (var value in values)
            {
                await ListItemDeleteAsync(connection, value, transaction);
            }
        }

        public static async Task ListItemDeleteAsync<T>(this DbConnection connection, IEnumerable<T> values) where T : BaseId
        {
            await connection.OpenAsync();

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    await ListItemDeleteAsync(connection, values, transaction);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public static async Task<IEnumerable<T>> ListLoadAsync<T>(this DbConnection connection, string sql = null, object param = null, DbTransaction transaction = null)
        {
            if (string.IsNullOrWhiteSpace(sql))
            {
                var query = new Query()
                {
                    Table = Sql.TableName<T>(),
                };

                sql = query.ToString();
            }

            DebugWriteSql(sql, param, "ListLoadAsync");

            try
            {
                var list = await connection.QueryAsync<T>(sql, param, transaction);

                return list;
            }
            catch (Exception e)
            {
                e.AddQuery(sql);

                throw;
            }
        }

        public static async Task<IEnumerable<T>> ListLoadAsync<T>(this DbConnection connection, Query query = null, object param = null, DbTransaction transaction = null)
        {
            if (query == null)
            {
                query = new Query()
                {
                    Table = Sql.TableName<T>(),
                };
            }

            var sql = query.ToString();

            return await ListLoadAsync<T>(connection, sql, param, transaction);
        }

        public static async Task<T> QuerySingleRowAsync<T>(this DbConnection connection, string sql, object param = null, DbTransaction transaction = null)
        {
            try
            {
                DebugWriteSql(sql, param, "QuerySingleRowAsync");

                return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
            }
            catch (Exception e)
            {
                e.AddQuery(sql);

                throw;
            }
        }

        public static async Task<T> QuerySingleRowAsync<T>(this DbConnection connection, Query query = null, object param = null, DbTransaction transaction = null)
        {
            if (query == null)
            {
                query = new Query()
                {
                    Table = Sql.TableName<T>(),
                };
            }

            var sql = query.ToString();

            return await QuerySingleRowAsync<T>(connection, sql, param, transaction);
        }

        public static async Task<T> ListItemLoadByIdAsync<T>(this DbConnection connection, DbTransaction transaction, long id) where T : BaseId
        {
            var query = new Query
            {
                Table = Sql.TableName<T>(),
                Where = $"id = :id"
            };

            return await QuerySingleRowAsync<T>(connection, query, new { id }, transaction);
        }

        public static async Task<int> ExecuteSqlAsync(this DbConnection connection, string sql, object param = null, DbTransaction transaction = null)
        {
            try
            {
                DebugWriteSql(sql, param, "ExecuteSqlAsync");

                return await connection.ExecuteAsync(sql, param, transaction);
            }
            catch (Exception e)
            {
                e.AddQuery(sql);

                throw;
            }
        }
    }
}