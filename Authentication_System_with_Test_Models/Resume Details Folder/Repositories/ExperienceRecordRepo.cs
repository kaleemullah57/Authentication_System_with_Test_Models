using Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;
using Dapper;
using System.Data;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Repositories
{
    public class ExperienceRecordRepo : IExperienceRecordInterface
    {
        private readonly IDbConnection _connection;
        public ExperienceRecordRepo(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        public async Task AddExperienceRecordAsync(int Id, int PersonalRecordId, ExperienceRecordModel ExperienceRecordModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            parameters.Add("PersonalRecordId", PersonalRecordId);
            parameters.Add("JobTitle", ExperienceRecordModel.JobTitle);
            parameters.Add("Location", ExperienceRecordModel.Location);
            parameters.Add("Role", ExperienceRecordModel.Role);
            parameters.Add("Description", ExperienceRecordModel.Description);
            parameters.Add("Technologies", ExperienceRecordModel.Technologies);
            parameters.Add("YearsOfExperience", ExperienceRecordModel.YearsOfExperience);

            await _connection.ExecuteAsync("AddExperienceRecordss", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> DeleteExperienceRecordById(int PersonalRecordId, int ExperienceId)
        {
            var parameters = new {PersonalRecordId = PersonalRecordId, ExperienceId = ExperienceId};
            var result = await _connection.ExecuteAsync(
                "DeleteExperienceRecordById",
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return result > 0;
        }

        public async Task<bool> UpdateExperienceRecord(int Id, int PersonalRecordId, ExperienceRecordModel experienceRecordModel)
        {
            var parameters = new
            {
                Id = Id,
                PersonalRecordId = PersonalRecordId,
                JobTitle = experienceRecordModel.JobTitle,
                Location = experienceRecordModel.Location,
                Role = experienceRecordModel.Role,
                Description = experienceRecordModel.Description,
                Technologies = experienceRecordModel.Technologies,
                YearsOfExperience = experienceRecordModel.YearsOfExperience,
                ExperienceId = experienceRecordModel.ExperienceId
            };
            var result = await _connection.ExecuteAsync(
                "UpdateExperienceRecord",
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return result > 0;
        }
    }
}
