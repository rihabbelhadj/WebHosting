using WEBHostingbackend.Repository;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace WEBHostingbackend.Infrastructure.Repository
{
  
        public class ServeursRepository : IServeurRepository
        {
            #region Fields
            private WebHostingDbContext context;
            #endregion
            #region Constructor
            public ServeursRepository(WebHostingDbContext _context)
            {
                context = _context;

            }

        public void Add(Serveur comp)
        {
            var serveurNew = new Serveur
            {

                //IdServeur = comp.IdServeur,
                PlateformeType = comp.PlateformeType,
                HostName = comp.HostName,
                Prix = comp.Prix,
                NbAutorisé = comp.NbAutorisé
            };

            context.Serveurs.Add(serveurNew);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var servToChange = context.Serveurs.FirstOrDefault(n => n.IdServeur == id);
            if (servToChange != null)
            {
                context.Serveurs.Remove(servToChange);

                context.SaveChanges();
            }
           
        }

        public Serveur GetById(int id)
        {
            var dto = new Serveur();

            var comp = context.Serveurs.Find(id);

            if (comp != null)
            {
                dto.IdServeur = comp.IdServeur;
                dto.PlateformeType = comp.PlateformeType;
                dto.HostName = comp.HostName;
                dto.Prix = comp.Prix;
                dto.NbAutorisé = comp.NbAutorisé;
            }
            else
            {
                throw new Exception($"Article with ID = {id} was not found.");
            }

            return dto;

        }
        #endregion

        #region Methods
        public List<Serveur> getServeurs()
            {

                /** return  this.context.Serveurs.Select(x => new Serveurs { name = x.name,
                 id = x.id,
                 description= x.description,
                 price =x.price }).ToList();**/

                var dtos = new List<Serveur>();
                var Serveurs = context.Serveurs.ToList();
                dtos.AddRange(Serveurs.Select(comp => new Serveur()
                {


                    IdServeur = comp.IdServeur,
                    PlateformeType = comp.PlateformeType,
                    HostName = comp.HostName,
                    Prix = comp.Prix,
                    NbAutorisé = comp.NbAutorisé

                }).ToList());

                return dtos;




            }

        public Serveur Update(Serveur comp)
        {

            var servToChange = context.Serveurs.Where(d => d.IdServeur == comp.IdServeur).FirstOrDefault();
            context.Attach(servToChange);

            servToChange.IdServeur = comp.IdServeur;
            servToChange.PlateformeType = comp.PlateformeType;
            servToChange.HostName = comp.HostName;
            servToChange.Prix = comp.Prix;
            servToChange.NbAutorisé = comp.NbAutorisé;

            context.Entry(servToChange).State = EntityState.Modified;
            context.Update(servToChange);
            context.SaveChangesAsync();
            return comp;
        }
        #endregion
    }
    
}
