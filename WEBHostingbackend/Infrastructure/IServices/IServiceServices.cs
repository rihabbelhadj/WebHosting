using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.IServices
{
    public interface IServiceServices
    {
        List<Service> GetService();

        void Add(Service serv);

        Service Update(Service serv);


        String Delete(int id);

        Service GetById(int id);
    }
}
