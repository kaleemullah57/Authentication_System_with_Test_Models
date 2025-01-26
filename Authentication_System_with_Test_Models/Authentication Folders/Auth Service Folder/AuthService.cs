using Authentication_System_with_Test_Models.Authentication_Folders.Auth_Models.User_Models;
using Authentication_System_with_Test_Models.Authentication_Folders.JWT_Helper_Folder;
using Authentication_System_with_Test_Models.Authentication_Folders.Repositories;

namespace Authentication_System_with_Test_Models.Authentication_Folders.Auth_Service_Folder
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;
        private readonly JWTHelper _jwthelper;

        public AuthService(JWTHelper jwthelper, UserRepository userRepository)
        {
            _jwthelper = jwthelper;
            _userRepository = userRepository;
        }







        public async Task Register(UserRegisterModel model)
        {
            var existingUser = await _userRepository.GetUserByEmail(model.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };

            await _userRepository.RegisterUser(user);
        }














        // Login user and generate JWT token
        public async Task<string> Login(UserLoginModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                throw new Exception("Invalid credentials.");
            }

            // Call GenerateJwtToken instead of GenerateToken
            return _jwthelper.GenerateJwtToken(user);
        }
    } 
}
