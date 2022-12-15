using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }

        public UserModel Auth(string email) =>
         _mySqlContext.Set<UserModel>().FirstOrDefault(e => e.Email == email);

        public bool CheckImmobil(int idUser, int idImm) {

            var imm = _mySqlContext.Set<UserPreferenceModel>().FirstOrDefault(e => e.UserId == idUser && e.ImmobileId == idImm);
            return imm == null ? false : true;
           
         }

        public void AddFavorite(int idUser, int idImm)
        {
            var favorite = new UserPreferenceModel();
            favorite.UserId = idUser;
            favorite.ImmobileId = idImm;
            _mySqlContext.Set<UserPreferenceModel>().Add(favorite);
            _mySqlContext.SaveChanges();

        }
        public void removeFavorite(int idUser, int idImm)
        {
            var favorite = new UserPreferenceModel();
            favorite.UserId = idUser;
            favorite.ImmobileId = idImm;
            _mySqlContext.Set<UserPreferenceModel>().Remove(favorite);
            _mySqlContext.SaveChanges();
        }
    }
}
