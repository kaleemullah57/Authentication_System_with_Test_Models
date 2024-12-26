using Authentication_System_with_Test_Models.Authentication_Folders.Auth_Models.User_Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication_System_with_Test_Models.Authentication_Folders.JWT_Helper_Folder
{
    public class JWTHelper
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;



        public JWTHelper(IConfiguration configuration)
        {
            _key = configuration["Jwt:Key"] ?? throw new Exception("Jwt:Key is null or missing in appsettings.json");
            _issuer = configuration["Jwt:Issuer"] ?? throw new Exception("Jwt:Issuer is null or missing in appsettings.json");
            _audience = configuration["Jwt:Audience"] ?? throw new Exception("Jwt:Audience is null or missing in appsettings.json");
        }




        public string GenerateJwtToken(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null");

            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Email) || user.Id == 0)
                throw new Exception("Invalid user data provided for token generation");

            var claims = new[]
              {
                  new Claim(ClaimTypes.Name, user.Username),
                  new Claim(ClaimTypes.Email, user.Email),
                  new Claim("Id", user.Id.ToString()) // Add Id claim here
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _issuer,     // Should match Jwt:Issuer
                _audience,   // Should match Jwt:Audience
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
