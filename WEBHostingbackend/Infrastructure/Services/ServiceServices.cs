using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.Services
{
    public class ServiceServices : IServiceServices
    {
        #region
        private readonly IServiceRepository _iServiceRepository;
        #endregion
        #region Constructor
        public ServiceServices(IServiceRepository iServiceRepository)
        {
            _iServiceRepository = iServiceRepository;
        }
        #endregion
        #region Methods
        public void Add(Service serv)
        {
            _iServiceRepository.Add(serv);
        }

        public string Delete(int id)
        {
           var value= _iServiceRepository.Delete(id);
            return value;
        }

        public Service GetById(int id)
        {
            var result = _iServiceRepository.GetById(id);
            return result;
        }

        public List<Service> GetService()
        {
            var result = _iServiceRepository.GetService();
            return result;
        }

        public Service Update(Service serv)
        {
            var value = _iServiceRepository.Update(serv);
            return serv;
        }
        #endregion
    }
}
