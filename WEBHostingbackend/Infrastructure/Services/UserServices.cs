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
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void deleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            var result = _iUserRepository.GetUsers();
            return result;
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
