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
            parameters.Add("YearsOfExperience", ExperienceRecordModel.YearsOfExperience);

            await _connection.ExecuteAsync("AddExperienceRecordss", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateExperienceRecord(int Id, int PersonalRecordId, ExperienceRecordModel experienceRecordModel)
        {
            var parameters = new
            {
                Id = Id,
                PersonalRecordId = PersonalRecordId,
                JobTitle = experienceRecordModel.JobTitle,
                Location = experienceRecordModel.Location,
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
