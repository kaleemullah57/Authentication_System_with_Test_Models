using System.Security.Claims;

namespace Authentication_System_with_Test_Models.Authentication_Folders.Auth_Models.User_Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public ClaimsIdentity? Role { get; internal set; }
    }
}
