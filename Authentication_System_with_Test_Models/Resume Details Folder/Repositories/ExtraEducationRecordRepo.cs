using Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;
using Dapper;
using FluentAssertions;
using System.Data;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Repositories
{
    public class ExtraEducationRecordRepo : IExtraEducationRecordInterface
    {
        private readonly IDbConnection _connection;
        public ExtraEducationRecordRepo(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }
        public async Task AddExtraEducationRecordAsync(int Id, int PersonalRecordId, ExtraEducationModel ExtraEducationModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            parameters.Add("PersonalRecordId", PersonalRecordId);
            parameters.Add("ExEduDegree", ExtraEducationModel.ExEduDegree);
            parameters.Add("ExEduInstitute", ExtraEducationModel.ExEduInstitute);
            parameters.Add("ExEduYearOfCompletion", ExtraEducationModel.ExEduYearOfCompletion);

            await _connection.ExecuteAsync("AddExEduRecordss", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateExtraEducationRecordAsync(int Id, int PersonalRecordId, ExtraEducationModel extraEducationModel)
        {
            var parameters = new
            {

                ExEducationId = extraEducationModel.ExEducationId,
                ExEduDegree = extraEducationModel.ExEduDegree,
                ExEduInstitute = extraEducationModel.ExEduInstitute,
                ExEduYearOfCompletion = extraEducationModel.ExEduYearOfCompletion,
                PersonalRecordId = PersonalRecordId,
                Id = Id
            };
            var result = await _connection.ExecuteAsync(
                "UpdateExEduRecord",
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return result > 0;
        }
    }
}
