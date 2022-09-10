using WEBHostingbackend.Infrastructure.IServices;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.Services
{
    public class PayementServices : IPayementServices
    {
        #region
        private readonly IPayementRepository _iPayementRepository;
        #endregion
        #region Constructor
        public PayementServices(
        IPayementRepository iPayementRepository)
        {
            _iPayementRepository = iPayementRepository;
        }
        #endregion
        #region Methods
        public void Add(Payement pay)
        {
            _iPayementRepository.Add(pay);
        }

       

        public Payement Delete(Payement pay)
        {
            var value = _iPayementRepository.Delete(pay);
            return pay;
        }

        public Payement GetById(int id)
        {
            var result = _iPayementRepository.GetById(id);
            return result;
        }

        public List<Payement> getByUserId(Guid idUser)
        {
            var result = _iPayementRepository.getByUserId(idUser);
            return result;
        }

        public List<Payement> GetPayements()
        {
            var result = _iPayementRepository.GetPayements();
            return result;
        }

        public Payement Update(Payement pay)
        {
            var value = _iPayementRepository.Update(pay);
            return pay;
        }
        public List<Payement> getByStatus(int status)
        {
            var list = _iPayementRepository.getByStatus(status);
            return list;
        }
        #endregion
    }
}
