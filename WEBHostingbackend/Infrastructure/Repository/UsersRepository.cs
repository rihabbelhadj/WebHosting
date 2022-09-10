using Microsoft.EntityFrameworkCore;
using WEBHostingbackend.Repository;
using WEBHostingbackend.Repository.IRepository;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Infrastructure.Repository
{
    public class UsersRepository : IUserRepository
    {
        #region Fields
        private readonly WebHostingDbContext _entities;

       
        #endregion
        #region Constructor
        public UsersRepository(WebHostingDbContext entities)
        {
            _entities = entities;
        
        }

        #endregion

        #region Methods
        public void Add(ApplicationUserModel user)
        {
            throw new NotImplementedException();
        }

        public string Delete(Guid id)
        {
            var userToChange = _entities.ApplicationUser.Where(d => d.Id == id).FirstOrDefault();
            _entities.Attach(userToChange);

            // userToChange.IsValid = false;

            _entities.Entry(userToChange).State = EntityState.Modified;
            _entities.Update(userToChange);
            _entities.SaveChangesAsync();

            return "Deleted";
        }

        public void deleteUser(Guid id)
        {
            var user = _entities.ApplicationUser.Where(x => x.Id == id).FirstOrDefault();
            _entities.ApplicationUser.Remove(user);
            _entities.SaveChanges();
        }

        public ApplicationUserModel GetById(Guid id)
        {
            var dto = new ApplicationUserModel();
            var user = _entities.ApplicationUser.Find(id);
            if (user != null)
            {
                dto.Id = user.Id;
                dto.phone = user.phone;
                dto.fullName = user.fullName;
                dto.firstName = user.firstName;
                dto.lastName = user.lastName;
                dto.UserName = user.UserName;
                dto.Email = user.Email;
                dto.Entreprise = user.Entreprise;
                dto.type = user.type;
            }
            else
            {
                throw new Exception($"Article with ID = {id} was not found.");
            }
            return dto;

        }
           public  List<ApplicationUserModel> GetUsersByRole(string type)
           {

           
            var dto = new List<ApplicationUserModel>();
            var user = _entities.ApplicationUser.Where(u => u.type == type).ToList();
            dto.AddRange(user.Select(users => new ApplicationUserModel()
            {
                Id = users.Id,
                phone = users.phone,
                fullName = users.fullName,
                firstName = users.firstName,
                lastName = users.lastName,
                UserName = users.UserName,
                Email = users.Email,
                Entreprise = users.Entreprise,
                type = users.type,
            }).ToList());
           
            return dto;

        }

        public List<ApplicationUserModel> GetUsers()
        {
           
            var dtos = new List<ApplicationUserModel>();
            var users = _entities.ApplicationUser/*.Include(C => C.Files).ToList()*/;
            dtos.AddRange(users.Select(user => new ApplicationUserModel()
            {
                Id = user.Id,

                UserName = user.UserName,
                fullName = user.fullName,
                firstName = user.firstName,
                type= user.type,
                lastName = user.lastName,
                Entreprise = user.Entreprise,
              
                Email = user.Email,
                
                phone = user.phone,
           

                /*files = _iFileRepository.getFilesByUserId(user.Id)*/
            }).ToList()) ;

            return dtos;
        }

        public ApplicationUserModel Update(ApplicationUserModel user)
        {
            //var userToChange = _entities.AspNetUsers.FirstOrDefault();
            var userToChange = _entities.ApplicationUser.Where(d => d.Id == user.Id).FirstOrDefault();
            _entities.Attach(userToChange);
            userToChange.Id = user.Id;
            ////userToChange.UserTypeId = user.UserTypeId;
            userToChange.UserName = user.UserName;
            userToChange.phone = user.phone;
            userToChange.firstName = user.firstName;
            userToChange.lastName = user.lastName;
           // userToChange.password = user.Password;
            //userToChange.fullName = user.fullName;
            userToChange.Email = user.Email;
            userToChange.Entreprise = user.Entreprise;
            userToChange.type = user.type;
            _entities.Entry(userToChange).State = EntityState.Modified;
            _entities.Update(userToChange);
            _entities.SaveChangesAsync();
            return user;
        }
        #endregion
    }
}
