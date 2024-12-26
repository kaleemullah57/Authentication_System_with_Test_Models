using Authentication_System_with_Test_Models.Resume_Details_Folder.Final_Resume_Model;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;
using Dapper;
using System.Data;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Repositories
{
    public class FinalResumeRepository : IFinalResumeInterface
    {
        private readonly IDbConnection _dbConnection;
        public FinalResumeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }



        public async Task<List<FinalResumeModel>> GetAllDataOfLoggedInUser(int Id)
        {
            using var multi = await _dbConnection.QueryMultipleAsync(
                "GetFinalResumeData",
                new { Id = Id },
                commandType: CommandType.StoredProcedure
            );

            var personalRecords = (await multi.ReadAsync<PersonalRecordModel>()).ToList();
            var educationRecords = (await multi.ReadAsync<EducationRecordModel>()).ToList();
            var expEduRecords = (await multi.ReadAsync<ExtraEducationModel>()).ToList();
            var experienceRecords = (await multi.ReadAsync<ExperienceRecordModel>()).ToList();
            var skillsRecords = (await multi.ReadAsync<SkillsModel>()).ToList();
            var languageRecords = (await multi.ReadAsync<LanguageModel>()).ToList();

            // Map each personal record with its related data
            var finalResumes = personalRecords.Select(personalRecord => new FinalResumeModel
            {
                PersonalRecord = personalRecord,
                Educations = educationRecords.Where(e => e.PersonalRecordId == personalRecord.PersonalRecordId).ToList(),
                ExtraEducations = expEduRecords.Where(e => e.PersonalRecordId == personalRecord.PersonalRecordId).ToList(),
                Experience = experienceRecords.Where(e => e.PersonalRecordId == personalRecord.PersonalRecordId).ToList(),
                Skills = skillsRecords.Where(s => s.PersonalRecordId == personalRecord.PersonalRecordId).ToList(),
                Languages = languageRecords.Where(l => l.PersonalRecordId == personalRecord.PersonalRecordId).ToList()
            }).ToList();

            return finalResumes;  // Return a list of FinalResumeModel
        }
































        public async Task<bool> DeleteAllRecordsByPersonalRecordId(int personalRecordId, int Id)
        {
            var parameters = new { PersonalRecordId = personalRecordId, Id = Id };
            var result = await _dbConnection.ExecuteAsync(
                "DeleteAllRecordsByPersonalRecordId", // Stored procedure name
                parameters, // Parameters to pass to the stored procedure
                commandType: CommandType.StoredProcedure
            );
            return result > 0; // Return true if deletion is successful
        }












    }
}
