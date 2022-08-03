using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.IServices
{
    public interface IDomainServices
    {
        List<Domain> GetDomains();
        Domain Update(Domain domain);

        void Add(Domain domain);

        String Delete(int id);
        Domain GetById(int id);

       List< Domain> GetDomainsbyUserId(Guid id);
        List<Domain> GetDomainesByTitle(string title);
    }
}
