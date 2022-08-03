using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Repository.IRepository
{
    public interface IPayementRepository
    {
        List<Payement> GetPayements();

        void Add(Payement pay);

        Payement Update(Payement pay);


        Payement Delete(Payement pay);

        Payement GetById(int id);
        List<Payement> getByUserId(Guid userId);
        Task<Object> AddPayement(Payement pay);
    }
}
