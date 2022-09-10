using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.IServices
{
    public interface ICommandeServices
    {
        List<Commande> GetCommande();

        Commande Add(Commande com);

        Commande Update(Commande com);


        String Delete(int id);

        Commande GetById(int id);
        List<Commande> GetBydomaineId(int id);
        List<Commande> GetByServiceId(int id);

    }
}
