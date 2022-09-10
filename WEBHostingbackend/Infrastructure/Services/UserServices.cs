using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.Services
{
    public class UserServices : IUserServices
    {
        #region
        private readonly IUserRepository _iUserRepository;
        #endregion
        #region Constructor

        public UserServices(IUserRepository iuserRepository)
        {
            _iUserRepository = iuserRepository;
        }
        #endregion
        #region Methods
        public void Add(ApplicationUserModel user)
        {
            _iUserRepository.Add(user);
        }

        public string Delete(Guid id)
        {
            var value = _iUserRepository.Delete(id);
            return (String)value;
        }

        public void deleteUser(Guid id)
        {
            _iUserRepository.deleteUser(id);
        }

        public ApplicationUserModel GetById(Guid id)
        {
            var result = _iUserRepository.GetById(id);
            return result;
        }

        public List<ApplicationUserModel> GetUsers()
        {
            var result = _iUserRepository.GetUsers();
            return result;
        }
        public List<ApplicationUserModel> GetUsersByRole(string type)
        {
            return _iUserRepository.GetUsersByRole(type);
        }
        public ApplicationUserModel Update(ApplicationUserModel user)
        {
            var value = _iUserRepository.Update(user);
            return user;
        }
        #endregion
    }
}
