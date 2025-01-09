using System.ComponentModel.DataAnnotations;

namespace patterns_pr3.Core.Entities
{
    public class User
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Role")]
        public Role Role { get; set; }     

        public User(int id, string login, string password, Role role)
        {
            Id = id;
            Login = login;
            Password = password;
            Role = role;
        }

        public User(string login, string password, Role role)
        {
            Login = login;
            Password = password;
            Role = role;
        }

        public User()
        {
            // Default constructor for creating an empty User object
        }
    }

    public enum Role {
        ADMIN =1,
        USER
    }

}
