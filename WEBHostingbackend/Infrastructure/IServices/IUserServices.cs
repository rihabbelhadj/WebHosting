using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.IServices
{
    public interface IUserServices
    {
        List<User> GetUsers();
        User Update(User user);

        void Add(User user);

        String Delete(int id);
        User GetById(int id);
        void deleteUser(int id);

    }
}
