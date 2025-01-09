using Microsoft.CodeAnalysis.Scripting;
using patterns_pr3.Core.DAO;
using BCrypt.Net;
using patterns_pr3.Core.Entities;

namespace patterns_pr3.Core.Proxy
{
    public class AuthenticationService
    {
        private readonly IUserDAO _userDAO;

        public AuthenticationService(IUserDAO userDAO)
        {
            _userDAO = userDAO;
        }

        public bool RegisterUser(string login, string password, Role role)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            _userDAO.CreateUser(login, hashedPassword,role );
            return true;
        }

        public User? AuthenticateUser(string login, string password)
        {
            var user = _userDAO.GetUserByLogin(login);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;
        }
    }
}
