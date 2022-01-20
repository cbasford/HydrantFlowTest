using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Dapper;

namespace DataAccessLibrary.DataAccess
{
	internal static class SqlDataAccess
	{
		internal static IEnumerable<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString, bool isStoredProcedure = false)
		{
			CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

			using ( IDbConnection connection = new SqlConnection(connectionString) )
			{
				IEnumerable<T> rows = connection.Query<T>(sqlStatement, parameters, commandType: commandType);
				return rows;
			}
		}

		internal static Task<IEnumerable<T>> LoadDataAsync<T, U>(string sqlStatement, U parameters, string connectionString, bool isStoredProcedure = false)
		{
			CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

			using ( IDbConnection connection = new SqlConnection(connectionString) )
			{
				Task<IEnumerable<T>> rows = connection.QueryAsync<T>(sqlStatement, parameters, commandType: commandType);
				return rows;
			}
		}

		internal static void SaveData<T>(string sqlStatement, T parameters, string connectionString, bool isStoredProcedure = false)
		{
			CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

			using ( IDbConnection connection = new SqlConnection(connectionString) )
			{
				_ = connection.Execute(sqlStatement, parameters, commandType: commandType);
			}
		}

		internal static Task SaveDataAsync<T>(string sqlStatement, T parameters, string connectionString, bool isStoredProcedure = false)
		{
			CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;

			using ( IDbConnection connection = new SqlConnection(connectionString) )
			{
				return connection.ExecuteAsync(sqlStatement, parameters, commandType: commandType);
			}
		}
	}
}
