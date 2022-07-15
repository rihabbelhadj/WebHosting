using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Repository.IRepository
{
    public interface IUserRepository
    {

        List<ApplicationUserModel> GetUsers();

        void Add(ApplicationUserModel user);

        ApplicationUserModel Update(ApplicationUserModel user);


        String Delete(Guid id);

        ApplicationUserModel GetById(Guid id);
        void deleteUser(Guid id);
    }
}
