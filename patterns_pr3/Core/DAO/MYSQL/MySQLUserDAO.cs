using MySqlConnector;
using patterns_pr3.Core.Entities;

namespace patterns_pr3.Core.DAO.MYSQL
{
    public class MySQLUserDAO : IUserDAO
    {
        private readonly DAOConfig daoConfig;

        public MySQLUserDAO()
        {
            daoConfig = DAOConfig.GetDAOConfig();
         
        }

        public void CreateUser(string login, string password, Role role)
        {
            try
            {
                // Create a new connection
                using (var connection = new MySqlConnection(daoConfig.Url))
                {
                    connection.Open();

                    // Prepare SQL query to insert the user
                    string query = "INSERT INTO USERS (login, password, role_id) VALUES (@login, @password, @role_id)";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        // Add parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password); // Make sure to hash the password before storing it
                        cmd.Parameters.AddWithValue("@role_id", role);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., database connection errors, query errors)
                Console.WriteLine($"An error occurred while creating the user: {login}");
            }
        }
    

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLogin(string login)
        {
            try
            {
                // Create a new connection
                using (var connection = new MySqlConnection(daoConfig.Url))
                {
                    connection.Open();

                    // SQL query to fetch the user by login
                    string query = "SELECT id, login, password, role_id FROM USERS WHERE login = @login";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        // Add parameter to avoid SQL injection
                        cmd.Parameters.AddWithValue("@login", login);

                        // Execute the query and get the result
                        using (var reader = cmd.ExecuteReader())
                        {
                            // Check if a user with the given login exists
                            if (reader.Read())
                            {
                                // Map the data to a User object
                                var user = new User
                                {
                                    Id = reader.GetInt32("id"),
                                    Login = reader.GetString("login"),
                                    Password = reader.GetString("password"),
                                    Role =(Role)reader.GetInt32("role_id")
                                };
                                return user;
                            }
                            else
                            {
                                // If no user is found, return null or throw an exception
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., database connection errors)
                Console.WriteLine("An error occurred while retrieving the user: " + ex.Message);
                return null;
            }

        }

        public void UpdateUser(int userId, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
