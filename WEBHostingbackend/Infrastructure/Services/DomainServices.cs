using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.Services
{
    public class DomainServices : IDomainServices
    {
        #region
        private readonly IDomainRepository _iDomainRepository;
        #endregion
        #region Constructor
        public DomainServices(
        IDomainRepository iDomainRepository)
        {
            _iDomainRepository = iDomainRepository;
        }
        #endregion
        #region Methods
        public void Add(Domain domain)
        {
            _iDomainRepository.Add(domain);
        }

        public string Delete(int id)
        {
            var value = _iDomainRepository.Delete(id);
            return value;
        }

        public Domain GetById(int id)
        {
            var result = _iDomainRepository.GetById(id);
            return result;
        }

        public List<Domain> GetDomains()
        {
            var result = _iDomainRepository.GetDomains();
            return result;
        }

        public List<Domain> GetDomainsbyUserId(Guid id)
        {
            var result = _iDomainRepository.GetDomainsbyUserId(id);
            return result;
        }

        public Domain Update(Domain domain)
        {
            var value = _iDomainRepository.Update(domain);
            return domain;
        }
        #endregion
    }
}
