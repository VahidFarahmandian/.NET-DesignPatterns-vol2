using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Design_Patterns_Vol2.Chapter_04.TableDataGateway
{
    public class UserTableDataGateway
    {
        private SqlConnection connection;
        public UserTableDataGateway()
        {
            connection = new SqlConnection("...");
        }
        public async Task<IDataReader> GetAllAsync()
        {
            return await new SqlCommand("" +
                "SELECT * " +
                "FROM Users", connection).ExecuteReaderAsync();
        }
        public async Task<IDataReader> FindByUserNameAsync(string username)
        {
            return await new SqlCommand($"" +
                $"SELECT * " +
                $"FROM Users " +
                $"WHERE UserName = N'{username}'", connection).ExecuteReaderAsync();
        }
        public async Task<bool> ChangePasswordAsync(string username, string newPassword)
        {
            return (await new SqlCommand($"" +
                $"UPDATE Users " +
                $"       SET [Password] = N'{newPassword}' " +
                $"WHERE UserName = N'{username}'", connection).ExecuteNonQueryAsync()) > 0;
        }
    }
}
