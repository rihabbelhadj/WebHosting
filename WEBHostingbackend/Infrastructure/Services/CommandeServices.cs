using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.Services
{
    public class CommandeServices : ICommandeServices
    {
        #region
        private readonly ICommandeRepository _iCommandeRepository;
        #endregion
        #region Constructor
        public CommandeServices(
        ICommandeRepository iCommandeRepository)
        {
            _iCommandeRepository = iCommandeRepository;
        }
        #endregion
        #region Action
        public Commande Add(Commande com)
        {
            var value =_iCommandeRepository.Add(com);
            return value;
        }

        public string Delete(int id)
        {
            var value = _iCommandeRepository.Delete(id);
            return value;
        }

        public Commande GetById(int id)
        {
            var result = _iCommandeRepository.GetById(id);
            return result;
        }
       public  List<Commande> GetBydomaineId(int id)
        {
            return _iCommandeRepository.GetBydomaineId(id);

        }
        public List<Commande> GetCommande()
        {
            var result = _iCommandeRepository.GetCommande();
            return result;
        }

        public Commande Update(Commande com)
        {
            var value = _iCommandeRepository.Update(com);
            return com;
        }
        #endregion
    }
}
