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
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void deleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
           
            var dtos = new List<User>();
            var users = _entities.Users/*.Include(C => C.Files).ToList()*/;
            dtos.AddRange(users.Select(user => new User()
            {
                IdUser = user.IdUser,


                Username = user.Username,

                Nom = user.Nom,
                Prenom = user.Prenom,
                Entreprise = user.Entreprise,
                Etat = user.Etat,
                Email = user.Email,
                Password = user.Password,
                Téléphone = user.Téléphone,
                Description = user.Description,
                Type = user.Type,
                IdRole = user.IdRole,
                
                /*files = _iFileRepository.getFilesByUserId(user.Id)*/
            }).ToList()) ;

            return dtos;
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
