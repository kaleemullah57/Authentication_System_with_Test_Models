using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Authentication_System_with_Test_Models.Database_Helper_Repository_Folder
{
    public class DbHelperRepo
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public DbHelperRepo(IConfiguration configuration )
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Default");
        }



        public DbConnection GetConnection()
            {
            return new SqlConnection(_connectionString);
            }
    }
}
