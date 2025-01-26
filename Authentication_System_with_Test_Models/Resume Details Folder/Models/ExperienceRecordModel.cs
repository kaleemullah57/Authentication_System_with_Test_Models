namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Models
{
    public class ExperienceRecordModel
    {
        public int ExperienceId { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Technologies { get; set; } = string.Empty;
        public string YearsOfExperience { get; set; } = string.Empty;
        public int PersonalRecordId { get; set; }
        public int Id { get; set; }
    }
}
