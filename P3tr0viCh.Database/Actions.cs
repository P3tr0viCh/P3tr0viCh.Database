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

        public static async Task<List<T>> ListLoadAsync<T>(DbConnection connection, Query query = null)
        {
            DebugWrite.Line(typeof(T).Name);

            if (query == null)
            {
                query = new Query()
                {
                    Table = Sql.TableName<T>(),
                };
            }

            var sql = query.ToString();

            DebugWrite.Line(sql);

            try
            {
                var list = await connection.QueryAsync<T>(sql);

                return list.AsList();
            }
            catch (Exception e)
            {
                Sql.ExceptionAddQuery(e, sql);

                throw;
            }
        }
    }
}