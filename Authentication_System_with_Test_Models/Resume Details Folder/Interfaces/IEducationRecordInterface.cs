using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces
{
    public interface IEducationRecordInterface
    {
        Task AddEducationRecordAsync ( int Id,int PersonalRecordId , EducationRecordModel EducationRecordModel);
        //Task<EducationRecordModel> GetPersonalRecordById(int Id);
        Task<bool> UpdateEducationRecord(int Id, int PersonalRecordId, EducationRecordModel educationRecordModel);

        Task<bool> DeleteEducationRecord(int PersonalRecordId, int EducationId);
    }
}
