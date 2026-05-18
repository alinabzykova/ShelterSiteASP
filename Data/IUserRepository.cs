using ShelterSiteNET.Models;

namespace ShelterSiteASP.Data
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(int id);
        User? GetByLogin(string login);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
