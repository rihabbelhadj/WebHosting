using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.IServices
{
    public interface IServeurServices
    {
        List<Serveur> GetServeurs();

        Serveur Update(Serveur comp);

        void Add(Serveur comp);

        public void Delete(int id);
        Serveur GetById(int id);
       
    }
}
