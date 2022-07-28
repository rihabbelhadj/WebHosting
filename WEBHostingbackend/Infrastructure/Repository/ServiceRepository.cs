using Microsoft.EntityFrameworkCore;
using WEBHostingbackend.Repository;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        #region Fields
        private readonly WebHostingDbContext _entities;
        #endregion
        #region Constructor
        public ServiceRepository(WebHostingDbContext entities)
        {
            _entities = entities;
        }
        public void Add(Service serv)
        {
            var serNew = new Service
            {
               IdService = serv.IdService,
               TypeHebergement = serv.TypeHebergement,  
               Prix=serv.Prix,
               BandePassante=serv.BandePassante,
               EspaceDisque=serv.EspaceDisque,
               NbEmail=serv.NbEmail,
               ServiceName = serv.ServiceName,
               TraficMesuel=serv.TraficMesuel


            };

            _entities.Services.Add(serNew);
            _entities.SaveChanges();
        }

        public string Delete(int id)
        {
            var servtochange = _entities.Services.Where(d => d.IdService == id).FirstOrDefault();
            _entities.Attach(servtochange);
            _entities.Entry(servtochange).State = EntityState.Modified;
            _entities.Update(servtochange);
            _entities.Services.Remove(servtochange);
            _entities.SaveChangesAsync();

            return "Deleted";
        }

        public Service GetById(int id)
        {
            var dto = new Service();

            var serv = _entities.Services.Find(id);

            if (serv != null)
            {
                dto.BandePassante = serv.BandePassante;
                dto.IdService=serv.IdService;
                dto.ServiceName = serv.ServiceName; 
                dto.TraficMesuel = serv.TraficMesuel;
                dto.EspaceDisque = serv.EspaceDisque;
                dto.NbEmail = serv.NbEmail;
                dto.Prix = serv.Prix;
                dto.TypeHebergement=serv.TypeHebergement;


            }
            else
            {
                throw new Exception($"Article with ID = {id} was not found.");
            }

            return dto;
        }

        public List<Service> GetService()
        {
            var dtos = new List<Service>();
            var servicees = _entities.Services.ToList();
            dtos.AddRange(servicees.Select(serv => new Service()
            {
                IdService=serv.IdService,
                ServiceName=serv.ServiceName,
                BandePassante= serv.BandePassante,
                EspaceDisque=serv.EspaceDisque,
                NbEmail=serv.NbEmail,
                Prix=serv.Prix,
                TraficMesuel=serv.TraficMesuel,
                TypeHebergement=serv.TypeHebergement

            }).ToList());

            return dtos;
        }

        public Service Update(Service serv)
        {

            var servToChange = _entities.Services.Where(d => d.IdService == serv.IdService).FirstOrDefault();
            _entities.Attach(servToChange);

            servToChange.IdService = serv.IdService;
            servToChange.ServiceName = serv.ServiceName;
            servToChange.TraficMesuel = serv.TraficMesuel;
            servToChange.Prix = serv.Prix;
            servToChange.BandePassante = serv.BandePassante;
            servToChange.EspaceDisque = serv.EspaceDisque;
            servToChange.NbEmail = serv.NbEmail;
            servToChange.TypeHebergement = serv.TypeHebergement;
            



            _entities.Entry(servToChange).State = EntityState.Modified;
            _entities.Services.Update(servToChange);
            //_entities.Services.Add(servToChange);
            _entities.SaveChangesAsync();
            return serv;
        }
        #endregion
    }
}
