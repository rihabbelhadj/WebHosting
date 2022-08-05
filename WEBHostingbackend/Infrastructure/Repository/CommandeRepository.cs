using Microsoft.EntityFrameworkCore;
using WEBHostingbackend.Repository;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.Repository
{
    public class CommandeRepository : ICommandeRepository
    {
        #region Fields
        private readonly WebHostingDbContext _entities;
        #endregion
        #region Constructor
        public CommandeRepository(WebHostingDbContext entities)
        {
            _entities = entities;
        }
        #endregion
        #region Action
        public Commande Add(Commande com)
        {
            var comNew = new Commande
            {
                IdCommande=com.IdCommande,
                IdDomaine=com.IdDomaine,
                IdService=com.IdService,
                NbAnnee=com.NbAnnee,
                IsValid=com.IsValid,
                Prix=com.Prix,
                TVA=com.TVA

                

            };

            _entities.Commande.Add(comNew);
            _entities.SaveChanges();
            return comNew;
        }

        public string Delete(int id)
        {
            var commandetochange = _entities.Commande.Where(d => d.IdCommande == id).FirstOrDefault();
            _entities.Attach(commandetochange);
            _entities.Entry(commandetochange).State = EntityState.Modified;
            _entities.Update(commandetochange);
            _entities.Commande.Remove(commandetochange);
            _entities.SaveChangesAsync();

            return "Deleted";
        }

        public Commande GetById(int id)

        {
            
          //  var jobsApplay = _entities.JobApply.Include(J => J.Job).ThenInclude(Jo => Jo.Company).ToList();



            var dto = new Commande();

            var com = _entities.Commande.Find(id);

            if (com != null)             
            {
                dto.IdCommande = com.IdCommande;
                dto.Serv=com.Serv;
                dto.IdService = com.IdService;
                dto.IdDomaine = com.IdDomaine;
                dto.TVA = com.TVA;
                dto.NbAnnee = com.NbAnnee;
                dto.IsValid = com.IsValid;
                dto.Prix=com.Prix;
                dto.Serv = new Service { IdService = com.Serv.IdService, ServiceName = com.Serv.ServiceName, BandePassante = com.Serv.BandePassante, EspaceDisque = com.Serv.EspaceDisque, NbEmail = com.Serv.NbEmail, Prix = com.Serv.Prix, TypeHebergement = com.Serv.TypeHebergement };
                dto.Dom = new Domain { IdDomain = com.Dom.IdDomain, DomainName = com.Dom.DomainName, IdDeBase = com.Dom.IdDeBase, Root = com.Dom.Root, HebergementType = com.Dom.HebergementType };


            }
            else
            {
                throw new Exception($"Article with ID = {id} was not found.");
            }

            return dto;
        }

        public List<Commande> GetCommande()
        {

            var dtos = new List<Commande>();


            // System.Diagnostics.Debug.WriteLine("Tesst "+ jobsApplay.FirstOrDefault().Status);


            var commandeApp = _entities.Commande.Include(J => J.Serv).Include(Jo=>Jo.Dom).ToList();

            var commande = _entities.Commande.ToList();
            dtos.AddRange(commandeApp.Select(dom => new Commande()
            {
                IdCommande=dom.IdCommande,
                IdDomaine=dom.IdDomaine,
                IdService=dom.IdService,
                NbAnnee=dom.NbAnnee,
                IsValid=dom.IsValid,
                Prix=dom.Prix,
                TVA=dom.TVA,
                Dom=new Domain { IdDomain = dom.Dom.IdDomain, DomainName = dom.Dom.DomainName, DateCreation = dom.Dom.DateCreation, HebergementType = dom.Dom.HebergementType,IdDeBase=dom.Dom.IdDeBase,Root=dom.Dom.Root },
                Serv=new Service { IdService=dom.Serv.IdService,ServiceName=dom.Serv.ServiceName,BandePassante=dom.Serv.BandePassante,Prix=dom.Serv.Prix,NbEmail=dom.Serv.NbEmail,EspaceDisque=dom.Serv.EspaceDisque,TypeHebergement=dom.Serv.TypeHebergement }

               
            }).ToList());;

            return dtos;
        }

        public Commande Update(Commande com)
        {
            var commandeToChange = _entities.Commande.Where(d => d.IdCommande == com.IdCommande).FirstOrDefault();
            _entities.Attach(commandeToChange);

            commandeToChange.IdService = com.IdService;
            commandeToChange.IdDomaine = com.IdDomaine;
            commandeToChange.IsValid = com.IsValid;
            commandeToChange.TVA = com.TVA;
            commandeToChange.NbAnnee = com.NbAnnee;
            commandeToChange.Prix = com.Prix;
            
            _entities.Entry(commandeToChange).State = EntityState.Modified;
            _entities.Update(commandeToChange);
           // _entities.Commande.Add(commandeToChange);
            _entities.SaveChangesAsync();
            return com;
        }
        public List<Commande> GetBydomaineId(int id)
        {
            var dtos = new List<Commande>();
            var comms = _entities.Commande.Where(x => x.IdDomaine == id).ToList();
            dtos.AddRange(comms.Select(com => new Commande()
            {
                IdCommande=com.IdCommande,
                IdDomaine=com.IdDomaine,
                IdService=com.IdService,
                IsValid=com.IsValid,
                TVA=com.TVA,
                NbAnnee=com.NbAnnee,
                Prix=com.Prix,
              // Dom = new Domain { IdDomain = com.Dom.IdDomain, DomainName = com.Dom.DomainName, DateCreation = com.Dom.DateCreation, HebergementType = com.Dom.HebergementType, IdDeBase = com.Dom.IdDeBase, Root = com.Dom.Root },
              // Serv = new Service { IdService = com.Serv.IdService, ServiceName = com.Serv.ServiceName, BandePassante = com.Serv.BandePassante, Prix = com.Serv.Prix, NbEmail = com.Serv.NbEmail, EspaceDisque = com.Serv.EspaceDisque, TypeHebergement = com.Serv.TypeHebergement }

            }).ToList());
            return dtos;
        }

        #endregion
    }
}
