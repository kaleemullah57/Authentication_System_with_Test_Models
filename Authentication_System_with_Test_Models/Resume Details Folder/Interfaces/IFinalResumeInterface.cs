    using Authentication_System_with_Test_Models.Resume_Details_Folder.Final_Resume_Model;
    using System.Data;

    namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces
    {
        public interface IFinalResumeInterface
        {
        Task<List<FinalResumeModel>> GetAllDataOfLoggedInUser(int Id);
        Task<bool> DeleteAllRecordsByPersonalRecordId(int PersonalRecordId, int Id);
        }
    }
