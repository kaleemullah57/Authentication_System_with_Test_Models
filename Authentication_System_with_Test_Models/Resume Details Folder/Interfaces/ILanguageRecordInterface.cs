using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Interfaces
{
    public interface ILanguageRecordInterface
    {
        Task AddLanguageRecordAsync(int Id, int PersonalRecordId, LanguageModel languageModel);
        //Task<LanguageModel> GetLanguageRecordById(int Id);
        Task <bool> UpdateLanguageRecordAsync (int Id, int PersonalRecordId, LanguageModel languageModel);
    }
}
