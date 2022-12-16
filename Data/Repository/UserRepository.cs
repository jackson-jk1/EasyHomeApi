using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }
        private string queryGetByImmbile = "Select distinct * from User u, UserPreference up where u.Id = up.userId and up.immobileId = ";
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

        public List<UserModel> getUsersByImmobile(int userId, int immId)
        {
            var user = _mySqlContext.Set<UserModel>().Where(u => u.Id == userId).FirstOrDefault();
            if (user != null)
            {
                queryGetByImmbile = queryGetByImmbile + $"'{immId}'";
                List<UserModel> users = _mySqlContext.Set<UserModel>().FromSqlRaw(queryGetByImmbile).ToList();
                users.Remove(user);
                return users;
            }
            return new List<UserModel>();
        }
    }
}
