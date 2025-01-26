using Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;
using Dapper;
using FluentAssertions;
using System.Data;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Repositories
{
    public class EducationRecordRepo : IEducationRecordInterface
    {
        private readonly IDbConnection _connection;
        public EducationRecordRepo(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }
        public async Task AddEducationRecordAsync(int Id, int PersonalRecordId, EducationRecordModel EducationRecordModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            parameters.Add("PersonalRecordId", PersonalRecordId);
            parameters.Add("Degree", EducationRecordModel.Degree);
            parameters.Add("Institute", EducationRecordModel.Institute);
            parameters.Add("YearOfCompletion", EducationRecordModel.YearOfCompletion);
            parameters.Add("GPA", EducationRecordModel.GPA);

            await _connection.ExecuteAsync("AddEducationRecordagain", parameters, commandType:CommandType.StoredProcedure);
        }

        public async Task<bool> DeleteEducationRecord(int PersonalRecordId, int EducationId)
        {
            var parameters = new { EducationId = EducationId, PersonalRecordId = PersonalRecordId };
            var result = await _connection.ExecuteAsync(
                "DeleteOnlyEducationRecord",
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return result > 0;
        }

        public async Task<bool> UpdateEducationRecord(int Id, int PersonalRecordId, EducationRecordModel educationRecordModel)
        {
            var parameters = new
            {
                Id = Id,
                PersonalRecordId = PersonalRecordId,
                EducationId = educationRecordModel.EducationId,
                Degree = educationRecordModel.Degree,
                Institute = educationRecordModel.Institute,
                YearOfCompletion = educationRecordModel.YearOfCompletion,
                GPA = educationRecordModel.GPA
            };
            var result = await _connection.ExecuteAsync(
                "UpdateEducationRecords",
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return result > 0;
        }
    }
}
