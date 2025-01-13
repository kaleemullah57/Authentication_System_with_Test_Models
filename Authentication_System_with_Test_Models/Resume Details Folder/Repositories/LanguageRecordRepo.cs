using Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;
using Dapper;
using System.Data;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Repositories
{
    public class LanguageRecordRepo : ILanguageRecordInterface
    {
        private readonly IDbConnection _connection;
        public LanguageRecordRepo(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        public async Task AddLanguageRecordAsync(int Id, int PersonalRecordId, LanguageModel languageModel)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id);
            parameters.Add("PersonalRecordId",PersonalRecordId);
            parameters.Add("LanguageName", languageModel.LanguageName);

            await _connection.ExecuteAsync("AddLanguageRecordss", parameters, commandType:CommandType.StoredProcedure);
        }

        public async Task<bool> DeleteLanguage(int PersonalRecordId, int LanguageId)
        {
           var parameter  = new { LanguageId = LanguageId, PersonalRecordId = PersonalRecordId };
            var result = await _connection.ExecuteAsync(
                "DeleteLanguageRecord",
                parameter,
                commandType: CommandType.StoredProcedure
                );
            return result > 0;
        }

        public async Task<bool> UpdateLanguageRecordAsync(int Id, int PersonalRecordId, LanguageModel languageModel)
        {
            var parameters = new
            {

                LanguageId = languageModel.LanguageId,
                LanguageName = languageModel.LanguageName,
                PersonalRecordId = PersonalRecordId,
                Id = Id
            };
            var result = await _connection.ExecuteAsync(
                "UpdateLanguageRecords",
                parameters,
                commandType: CommandType.StoredProcedure
                );
            return result > 0;
        }
    }
}
