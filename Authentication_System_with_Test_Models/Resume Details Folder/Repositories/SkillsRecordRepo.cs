using Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;
using Dapper;
using System.Data;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Repositories
{
    public class SkillsRecordRepo : ISkillsRecordInterface
    {
        private readonly IDbConnection _connection;
        public SkillsRecordRepo(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }
        public async Task AddSkillsRecordAsync(int Id, int PersonalRecordId, SkillsModel Skills)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            parameters.Add("PersonalRecordId", PersonalRecordId);
            parameters.Add("SkillName", Skills.SkillName);
            parameters.Add("Efficiency", Skills.Efficiency);

            await _connection.ExecuteAsync("AddSkillsRecordss", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> DeleteSkillsRecordById(int PersonalRecordId, int SkillId)
        {
            var parameters = new {PersonalRecordId = PersonalRecordId, SkillId = SkillId};
            var isDeleted = await _connection.ExecuteAsync(
                "DeleteSkillRecord",
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return isDeleted > 0;
        }

        public async Task<bool> UpdateSkillsRecordAsync(int Id, int PersonalRecordId, SkillsModel skillsModel)
        {
            var parameters = new
            {
                SkillId = skillsModel.SkillId,
                SkillName = skillsModel.SkillName,
                Efficiency = skillsModel.Efficiency,
                PersonalRecordId = PersonalRecordId,
                Id = Id
            };
            var result = await _connection.ExecuteAsync(
                "UpdateSkillsRecords",
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return result > 0;
        }
    }
}
