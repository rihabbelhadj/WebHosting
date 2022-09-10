using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.IServices
{
    public interface IPayementServices
    {
        List<Payement> GetPayements();

        Payement Update(Payement pay);

        void Add(Payement paye);
        
        Payement Delete(Payement pay);
        Payement GetById(int id);
        List<Payement> getByUserId(Guid userId);
         List<Payement> getByStatus(int status);


    }
}
