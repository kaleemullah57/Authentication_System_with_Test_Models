namespace Authentication_System_with_Test_Models.Resume_Details_Folder.Models
{
    public class ExtraEducationModel
    {
        public int ExEducationId { get; set; }
        public string ExEduDegree { get; set; } = string.Empty;
        public string ExEduInstitute { get; set; } = string.Empty;
        public string ExEduYearOfCompletion { get; set; } = string.Empty;
        public int PersonalRecordId { get; set; }
        public int Id { get; set; }

    }
}
