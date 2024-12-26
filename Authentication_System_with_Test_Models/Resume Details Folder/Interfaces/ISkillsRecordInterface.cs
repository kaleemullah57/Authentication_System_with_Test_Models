using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces
{
    public interface ISkillsRecordInterface
    {
        Task AddSkillsRecordAsync(int Id, int PersonalRecordId, SkillsModel Skills);
        //Task<SkillsModel> GetSKillsRecordById(int Id);
        Task<bool> UpdateSkillsRecordAsync(int Id, int PersonalRecordId, SkillsModel skillsModel);
    }
}
