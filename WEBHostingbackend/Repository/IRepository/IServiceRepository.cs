using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Repository.IRepository
{
    public interface IServiceRepository
    {
        List<Service> GetService();

        void Add(Service serv);

        Service Update(Service serv);


        String Delete(int id);

        Service GetById(int id);
        
    }
}
