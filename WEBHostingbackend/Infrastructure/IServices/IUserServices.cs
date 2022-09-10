using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.IServices
{
    public interface IUserServices
    {
        List<ApplicationUserModel> GetUsers();
        List<ApplicationUserModel> GetUsersByRole(string type);
        ApplicationUserModel Update(ApplicationUserModel user);

        void Add(ApplicationUserModel user);

        String Delete(Guid id);
        ApplicationUserModel GetById(Guid id);
        void deleteUser(Guid id);

    }
}
