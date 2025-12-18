using Dapper;
using Dapper.Contrib.Extensions;
using P3tr0viCh.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace P3tr0viCh.Database
{
    public static class Actions
    {
        public static async Task ListItemSaveAsync<T>(DbConnection connection, DbTransaction transaction, T value) where T : BaseId
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

        public static async Task ListItemDeleteAsync<T>(DbConnection connection, DbTransaction transaction, T value) where T : BaseId
        {
            await connection.DeleteAsync(value, transaction);
        }

        public static async Task<IEnumerable<T>> ListLoadAsync<T>(DbConnection connection, string sql)
        {
            DebugWrite.Line(typeof(T).Name);

            if (sql.IsEmpty())
            {
                var query = new Query()
                {
                    Table = Sql.TableName<T>(),
                };

                sql = query.ToString();
            }

            DebugWrite.Line(sql.ReplaceEol());

            try
            {
                var list = await connection.QueryAsync<T>(sql);

                return list;
            }
            catch (Exception e)
            {
                Sql.ExceptionAddQuery(e, sql);

                throw;
            }
        }

        public static async Task<IEnumerable<T>> ListLoadAsync<T>(DbConnection connection, Query query = null)
        {
            if (query == null)
            {
                query = new Query()
                {
                    Table = Sql.TableName<T>(),
                };
            }

            var sql = query.ToString();

            return await ListLoadAsync<T>(connection, sql);
        }
    }
}