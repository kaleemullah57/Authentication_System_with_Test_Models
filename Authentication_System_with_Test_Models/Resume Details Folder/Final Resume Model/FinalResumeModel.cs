using Authentication_System_with_Test_Models.Resume_Details_Folder.Models;

namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Final_Resume_Model
{
    public class FinalResumeModel
    {
        public PersonalRecordModel PersonalRecord { get; set; }
        public List<EducationRecordModel> Educations { get; set; } = new List<EducationRecordModel>();
        public List<ExtraEducationModel> ExtraEducations { get; set; } = new List<ExtraEducationModel>();
        public List<ExperienceRecordModel> Experience { get; set; } = new List<ExperienceRecordModel>();
        public List<SkillsModel> Skills { get; set; } = new List<SkillsModel>();
        public List<LanguageModel> Languages { get; set; } = new List<LanguageModel>();
    }
}
