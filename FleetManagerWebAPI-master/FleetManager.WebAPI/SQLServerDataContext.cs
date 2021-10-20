using FleetManager.WebAPI.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManager.WebAPI
{
    public class SQLServerDataContext : IDataContext<IDbConnection>
    {
        public static string _connectionString => $@"Data Source=BEYOND\SQLEXPRESS2K19;Initial Catalog=FleetManager_WPF;Integrated Security=True";



        public IDbConnection Open()
        {
            SqlConnection conn = new(_connectionString); // Er det en forkortelse af SqlConnection conn = new SqlConnection(ConnectionString);? 
            conn.Open();
            return conn;
        }
    }
}
