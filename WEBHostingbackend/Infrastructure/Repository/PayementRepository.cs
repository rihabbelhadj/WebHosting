using Microsoft.EntityFrameworkCore;
using WEBHostingbackend.Repository;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.Repository
{
    public class PayementRepository : IPayementRepository
    {
        #region Fields
        private readonly WebHostingDbContext _entities;
        #endregion
        #region Constructor
        public PayementRepository(WebHostingDbContext entities)
        {
            _entities = entities;
        }

        

        #endregion

        public void Add(Payement paye)
        {
            var PayNew = new Payement
            {
              idPayement=paye.idPayement,
              Type=paye.Type,
              Date=paye.Date,
              Status=paye.Status,
              idUser = paye.idUser,
              //User=paye.User,
            };

            _entities.Payement.Add(PayNew);
            _entities.SaveChanges();
        }

        public Task<object> AddPayement(Payement pay)
        {
            throw new NotImplementedException();
        }

        public Payement Delete(Payement pay)
        {
            var compToChange = _entities.Payement.Where(d => d.idPayement == pay.idPayement).FirstOrDefault();
            _entities.Attach(compToChange);
            _entities.Entry(compToChange).State = EntityState.Modified;
            _entities.Update(compToChange);
            _entities.Payement.Remove(compToChange);
            _entities.SaveChangesAsync();

            return pay;
        }

        public Payement GetById(int id)
        {
            var dto = new Payement();

            var pay = _entities.Payement.Find(id);

            if (pay != null)
            {
                dto.idPayement = pay.idPayement;
                dto.Type = pay.Type;
                dto.Date = pay.Date;
                dto.Status = pay.Status;
                dto.idUser = pay.idUser;
                
            }
            else
            {
                throw new Exception($"Article with ID = {id} was not found.");
            }

            return dto;
        }

        public List<Payement> getByUserId(Guid IdUser)
        {
            var dto = new List<Payement>();

            var pay = _entities.Payement.Where(d => d.idUser == IdUser).ToList();

            dto.AddRange(pay.Select(dom => new Payement()
            {
                idPayement = dom.idPayement,
                Type = dom.Type,
                Date = dom.Date,
                Status = dom.Status,
                idUser = dom.idUser,
                //dto.User=pay.User;



            }).ToList());
           

            return dto;
        }

        public List<Payement> GetPayements()
        {
            var dtos = new List<Payement>();
            var payements = _entities.Payement.ToList();
            dtos.AddRange(payements.Select(paye => new Payement()
            {

                idPayement = paye.idPayement,
                idUser = paye.idUser,
                Type = paye.Type,
                Date = paye.Date,
                Status = paye.Status,
                //User = paye.User,
                
                

            }).ToList());

            return dtos;
        }

        public Payement Update(Payement pay)
        {
            var compToChange = _entities.Payement.Where(d => d.idPayement == pay.idPayement).FirstOrDefault();
            _entities.Attach(compToChange);
            compToChange.Type = pay.Type;
            compToChange.Date = pay.Date;
            compToChange.Status = pay.Status;
           

            _entities.Entry(compToChange).State = EntityState.Modified;
            _entities.Update(compToChange);
            _entities.SaveChangesAsync();
            return pay;
        }
      /*  public async Task<Payement> DeleteEmployee(int employeeId)
        {
            var result = await WebHostingDbContext.Payement
                .FirstOrDefaultAsync(e => e.idPayement == employeeId);
            if (result != null)
            {
                WebHostingDbContext.Payement.Remove(result);
                await WebHostingDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }*/
       /* public async Task<Payement> GetEmployee(int employeeId)
        {
            return await WebHostingDbContext.Payement
                .FirstOrDefaultAsync(e => e.idPayement == employeeId);
        }*/

    }
}
