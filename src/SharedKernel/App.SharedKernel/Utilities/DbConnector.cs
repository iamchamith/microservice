using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace App.SharedKernel.Utilities
{
    public class DbConnector
    {
        public string ConnectionString { get; set; }
        public DbConnector()
        {
            ConnectionString = GlobalConfig.ConnectionString;
        }
        public DbConnector(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public async Task Execute(string sql)
        {
            using (var conn = GetConnection())
            {
                await conn.ExecuteAsync(sql);
            }
        }
    }
}
