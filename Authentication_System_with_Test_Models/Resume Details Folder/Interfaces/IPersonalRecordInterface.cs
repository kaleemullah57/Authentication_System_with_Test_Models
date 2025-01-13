using Authentication_System_with_Test_Models.Resume_Details_Folder.Final_Resume_Model;
using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces
{
    public interface IPersonalRecordInterface
    {
        Task<int> AddPersonalRecodAsync (int id, PersonalRecordModel personalRecordz);
        //Task<PersonalRecordModel> GetPersonalRecordById(int Id);
    }
}
