using Infraestructure.Enum;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public sealed class DbConnection : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public string Sql { get; set; }

        public DbConnection() { }

        public DbConnection(string connectionString, DatabaseType type)
        {
            Connection = GetConnection(connectionString, type);
        }
        public void Dispose() => Connection?.Dispose();

        public void Close() => Connection?.Close();

        private static IDbConnection GetConnection(string connectionString, DatabaseType dbType)
        {
            return dbType switch
            {
                DatabaseType.MySql => new MySqlConnection(connectionString),
                _ => new MySqlConnection(connectionString),
            };

        }
    }
}
