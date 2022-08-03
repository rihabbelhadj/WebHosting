using Microsoft.EntityFrameworkCore;
using WEBHostingbackend.Repository;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.Repository
{
    public class DomainRepository : IDomainRepository
    {
        #region Fields
        private readonly WebHostingDbContext _entities;
        #endregion
        #region Constructor
        public DomainRepository(WebHostingDbContext entities)
        {
            _entities = entities;
        }
        public void Add(Domain domain)
        {
            var DomNew = new Domain
            {
                IdDomain= domain.IdDomain,
                IdDeBase= domain.IdDeBase,
                Root= domain.Root,
                DateCreation= domain.DateCreation,
                DomainName= domain.DomainName,
                HebergementType= domain.HebergementType,


            };

            _entities.Domain.Add(DomNew);
            _entities.SaveChanges();
        }

        public string Delete(int id)
        {
            var domaintochange = _entities.Domain.Where(d => d.IdDomain == id).FirstOrDefault();
            _entities.Attach(domaintochange);
            _entities.Entry(domaintochange).State = EntityState.Modified;
            _entities.Update(domaintochange);
            _entities.Domain.Remove(domaintochange);
            _entities.SaveChangesAsync();

            return "Deleted";
        }

        public Domain GetById(int id)
        {
            var dto = new Domain();

            var dom = _entities.Domain.Find(id);

            if (dom != null)
            {
                dto.IdDomain =dom.IdDomain;
                dto.DomainName = dom.DomainName;
                dto.DateCreation = dom.DateCreation;
                dto.IdDeBase = dom.IdDeBase;
                dto.Root = dom.Root;
                dto.HebergementType = dom.HebergementType;
               

            }
            else
            {
                throw new Exception($"Article with ID = {id} was not found.");
            }

            return dto;
        }

        public List<Domain> GetDomainesByTitle(string title)
        {
            var dtos = new List<Domain>();
            var domain = _entities.Domain.Where(j => j.DomainName.Contains(title)).ToList();
            dtos.AddRange(domain.Select(dom => new Domain()
            {
                IdDomain = dom.IdDomain,
                DomainName = dom.DomainName,
                DateCreation = dom.DateCreation,
                IdDeBase = dom.IdDeBase,
                Root=dom.Root,
                HebergementType=dom.HebergementType,
             

            }).ToList());
            return dtos;
        }

        public List<Domain> GetDomains()
        {
            var dtos = new List<Domain>();
            var Domaines = _entities.Domain.ToList();
            dtos.AddRange(Domaines.Select(dom => new Domain()
            {
                IdDomain = dom.IdDomain,
                DomainName=dom.DomainName,
                DateCreation=dom.DateCreation,
                Root=dom.Root,
                HebergementType=dom.HebergementType,
                IdDeBase=dom.IdDeBase,
                



            }).ToList());

            return dtos;
        }

        /*public Domain GetDomainsbyUserId(Guid id)
        {
            var dto = new   Domain();

            var pay = _entities.Domain.Where(d => d.IdDeBase == id).FirstOrDefault();

            if (pay != null)
            {
                dto.IdDomain = pay.IdDomain;
                dto.DomainName = pay.DomainName;
                dto.DateCreation = pay.DateCreation;
                dto.Root = pay.Root;
                dto.HebergementType = pay.HebergementType;
                dto.IdDeBase = pay.IdDeBase;
               
            }
            else
            {
            }

            return dto;
        }*/
        public List<Domain> GetDomainsbyUserId(Guid JobId)
        {
            var dtos = new List<Domain>();
            var doms = _entities.Domain.Where(x => x.IdDeBase == JobId).ToList();
            dtos.AddRange(doms.Select(dom => new Domain()
            {
                IdDomain = dom.IdDomain,
                DomainName = dom.DomainName,
                DateCreation = dom.DateCreation,
                Root = dom.Root,
                HebergementType = dom.HebergementType,
                IdDeBase = dom.IdDeBase,
               


            }).ToList());
            return dtos;
        }
        public Domain Update(Domain domain)
        {

            var domainToChange = _entities.Domain.Where(d => d.IdDomain == domain.IdDomain).FirstOrDefault();
            _entities.Attach(domainToChange);

            domainToChange.Root=domain.Root;
            domainToChange.DateCreation=domain.DateCreation;
            domainToChange.DomainName=domain.DomainName;
            domainToChange.HebergementType=domain.HebergementType;
            domainToChange.IdDeBase=domain.IdDeBase;

            
            _entities.Entry(domainToChange).State = EntityState.Modified;
            _entities.Update(domainToChange);
            _entities.Domain.Add(domainToChange);
            _entities.SaveChangesAsync();
            return domain;
        }
        #endregion
    }
}
