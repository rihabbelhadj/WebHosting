using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Repository.IRepository
{
    public interface IUserRepository
    {

        List<ApplicationUserModel> GetUsers();

        void Add(User user);

        User Update(User user);


        String Delete(int id);

        User GetById(int id);
        void deleteUser(int id);
    }
}
