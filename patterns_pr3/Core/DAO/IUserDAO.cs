using patterns_pr3.Core.Entities;

namespace patterns_pr3.Core.DAO
{
    public interface IUserDAO
    {
        void CreateUser(string login, string password, Role role);
        void UpdateUser(int userId, string newPassword);
       
        User GetUserById(int userId);
        User GetUserByLogin(string login);
    }
}
