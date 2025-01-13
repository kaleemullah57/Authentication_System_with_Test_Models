using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces
{
    public interface IExtraEducationRecordInterface
    {
        Task AddExtraEducationRecordAsync(int Id, int PersonalRecordId, ExtraEducationModel ExtraEducationModel);
        //Task<ExtraEducationModel> GetExtraEduRecordById(int Id);
        Task<bool> UpdateExtraEducationRecordAsync(int Id, int PersonalRecordId, ExtraEducationModel extraEducationModel);
        // Delete Extra Education Record By Id
        Task<bool> DeleteExtraEducationRecordById (int PersonalRecordId, int ExEducationId);
    }
}
