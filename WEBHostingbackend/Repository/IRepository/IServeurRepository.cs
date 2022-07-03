using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Repository.IRepository
{
    public interface IServeurRepository
    {
        List<Serveur> getServeurs();

        public void Add(Serveur comp);

        public Serveur Update(Serveur comp);


        public void Delete(int id);

        public Serveur GetById(int id);
        
    }
}
