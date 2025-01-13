using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces
{
    public interface IExperienceRecordInterface
    {
        Task AddExperienceRecordAsync(int Id, int PersonalRecordId, ExperienceRecordModel ExperienceRecordModel);
        //Task<ExperienceRecordModel> GetExperienceRecordById(int Id);
        Task<bool> UpdateExperienceRecord(int Id, int PersonalRecordId, ExperienceRecordModel experienceRecordModel);
        // Delete Experience record By id
        Task<bool> DeleteExperienceRecordById(int PersonalRecordId, int ExperienceId);
    }
}
