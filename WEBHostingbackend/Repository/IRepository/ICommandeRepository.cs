using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Repository.IRepository
{
    public interface ICommandeRepository
    {
        List<Commande> GetCommande();

        void Add(Commande com);

        Commande Update(Commande com);


        String Delete(int id);

        Commande GetById(int id);
    
        //List<Commande> GetDomainesByTitle(string title);
    }
}
