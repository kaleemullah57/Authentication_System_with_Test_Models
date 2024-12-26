namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Models
{
    public class EducationRecordModel
    {
        public int EducationId { get; set; }
        public string Degree     { get; set; } = string.Empty;
        public string Institute  { get; set; } = string.Empty;
        public string YearOfCompletion { get; set; } = string.Empty;
        public int PersonalRecordId { get; set; }
        public int Id { get; set; }
    }
}
