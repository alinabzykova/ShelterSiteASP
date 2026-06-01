using ShelterSiteNET.Models;
using System.Text.Json;
using System.Xml.Linq;

namespace ShelterSiteASP.Data
{
    public class UserRepository : IUserRepository
    {
        private static List<User> users = new List<User>();

        public UserRepository()
        {
            if (File.Exists("Data/users.json"))
            {
                string jsonString = File.ReadAllText("Data/users.json");
                users = JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
            }
        }
        public User? ValidateUser(string login, string password)
        {
            var users = GetAll();
            return users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }

        public bool UserExists(string login)
        {
            return GetAll().Any(u => u.Login == login);
        }
        public void AddUser(User user)
        {
            var users = GetAll();
            user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
            users.Add(user);
            SaveChanges();
        }
        public List<User> GetAll()
        {
            return users;
        }

        public User? GetById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetByLogin(string login)
        {
            return users.FirstOrDefault(u => u.Login == login);
        } 

        public void Update(User user)
        {
            var existing = GetById(user.Id);
            if (existing != null)
            {
                existing.Login = user.Login;
                existing.Password = user.Password;
                existing.Description = user.Description;
                SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                users.Remove(user);
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            string jsonString = JsonSerializer.Serialize(users);
            File.WriteAllText("Data/users.json", jsonString);
        }
         
        public bool IsAdmin(int userId)
        {
            var user = GetById(userId);
            return user != null && user.Role == "Admin";
        }
    }
}
