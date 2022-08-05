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
            throw new NotImplementedException();
        }

        public Commande GetById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        #endregion
    }
}
