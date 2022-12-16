using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        public UserModel Auth(string email);

        public bool CheckImmobil(int userId, int immId);

        public void AddFavorite(int idUser, int idImm);

        public void removeFavorite(int idUser, int idImm);

        public List<UserModel> getUsersByImmobile(int userId, int immId);
    }
}
