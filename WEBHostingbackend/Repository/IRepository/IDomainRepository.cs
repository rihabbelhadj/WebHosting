using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Repository.IRepository
{
    public interface IDomainRepository
    {
        List<Domain> GetDomains();

        void Add(Domain domain);

        Domain Update(Domain domain);


        String Delete(int id);

        Domain GetById(int id);
        List<Domain> GetDomainsbyUserId(Guid id);
    }
}
