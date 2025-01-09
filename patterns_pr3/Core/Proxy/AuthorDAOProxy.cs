using patterns_pr3.Core.DAO;
using patterns_pr3.Core.Entities;

namespace patterns_pr3.Core.Proxy
{
    public class AuthorDAOProxy
    {

        private readonly IAuthorDAO _authorDAO;
        public  User _currentUser { get; set; }

        public AuthorDAOProxy(DAOFactory factory)
        {
            _authorDAO = factory.GetAuthorDAO();
           
        }

        public void CreateAuthor(Author a)
        {
            CheckRole(Role.ADMIN,"Create Author");
            _authorDAO.AddAuthor(a);
        }

        public void UpdateAuthor(Author a)
        {
            CheckRole(Role.ADMIN,"Update Author");
            _authorDAO.UpdateAuthor(a);
        }

    
        public Author GetAuthorByName(string name, string surname)
        {
            return _authorDAO.GetAuthorByName(name,surname);
        }

        public Author GetAuthor(int id)
        {
            return _authorDAO.GetAuthor(id);
        }

        private void CheckRole(Role role,string operation)
        {
            if (_currentUser.Role != role)
            {
                throw new UnauthorizedAccessException($"{operation} Access Denied: Insufficient permissions.");
            }
        }
    }
}
