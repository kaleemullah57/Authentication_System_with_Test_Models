using Authentication_System_with_Test_Models.Authentication_Folders.Auth_Models.User_Models;
using Dapper;
using System.Data;

namespace Authentication_System_with_Test_Models.Authentication_Folders.Repositories
{
    public class UserRepository
    {
        private readonly IDbConnection _connection;
        public UserRepository(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }




        // Register User
        public async Task RegisterUser (User user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Username", user.Username);
            parameters.Add("Email", user.Email);
            parameters.Add("PasswordHash", user.PasswordHash);
            parameters.Add("CreatedDate", DateTime.UtcNow); // Add the CreatedDate parameter
            await _connection.ExecuteAsync("RegisterUsers", parameters, commandType: CommandType.StoredProcedure);
        }





        //Get User By Email
        //public async Task<User> GetUserByEmail(string Email)
        //{
        //    var parameters = new DynamicParameters();
        //    parameters.Add("Email", Email);

        //    return await _connection.QueryFirstOrDefaultAsync("GetUserByEmail", parameters, commandType: CommandType.StoredProcedure);
        //}


        // Get User By Email. 
        public async Task<User> GetUserByEmail(string email)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Email", email);

            // Use QueryFirstOrDefaultAsync and specify the result type
            return await _connection.QueryFirstOrDefaultAsync<User>(
                "GetUserByEmail",
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }




        // Count Registered Users
        public async Task<int> GetCountAllUsers()
        {
            var parameters = new DynamicParameters();
            const string storedProcedure = "CountAllRegisteredUsers";

            return await _connection.ExecuteScalarAsync<int>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure
                );
        }






    }
}
