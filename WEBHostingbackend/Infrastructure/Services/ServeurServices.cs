using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.Services
{
    public class ServeurServices : IServeurServices
    {
        #region
        private readonly IServeurRepository _iServeurRepository;
        #endregion

        #region Constructor
        public ServeurServices(IServeurRepository iServeurRepository)
        {
            _iServeurRepository = iServeurRepository;
        }
        #endregion

        #region Methods

        public List<Serveur> GetServeurs()
        {
            var result = _iServeurRepository.getServeurs();
            return result;
        }
        public void Add(Serveur comp)
        {
            _iServeurRepository.Add(comp);
        }



        public Serveur GetById(int id)
        {
            var result = _iServeurRepository.GetById(id);
            return result;
        }

      


        public Serveur Update(Serveur comp)
        {

            var value = _iServeurRepository.Update(comp);
            return comp  /*(String)value*/;
        }


        public void Delete(int id)
        {
             _iServeurRepository.Delete(id);
           
        }

        #endregion
    }
}
