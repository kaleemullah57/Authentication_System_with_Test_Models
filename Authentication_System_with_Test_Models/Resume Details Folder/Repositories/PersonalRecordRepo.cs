using Authentication_System_with_Test_Models.Resume_Details_Folder.Final_Resume_Model;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;
using Dapper;
using System.Data;
using System.Data.Common;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Repositories
{
    public class PersonalRecordRepo : IPersonalRecordInterface
    {
        private readonly IDbConnection _dbConnection;
        public PersonalRecordRepo(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<int> AddPersonalRecodAsync(int id, PersonalRecordModel personalRecord)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            parameters.Add("Name", personalRecord.Name);
            parameters.Add("Email", personalRecord.Email);
            parameters.Add("Phone", personalRecord.Phone);
            parameters.Add("Address", personalRecord.Address);
            parameters.Add("ImagePath", personalRecord.ImagePath);
            parameters.Add("Intro", personalRecord.Intro);


             return await _dbConnection.ExecuteScalarAsync<int>("AddPersonalRecordss", parameters, commandType:CommandType.StoredProcedure);
        }













    }
}
