using Data.Context;
using Data.Migrations;
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
        
        private string queryGetContacts = "select u.* from User u, Contacts c where u.Id = c.contactId and c.userId = ";

        public UserModel auth(string email) =>
         _mySqlContext.Set<UserModel>().FirstOrDefault(e => e.Email == email);

        public bool checkImmobil(int idUser, int idImm)
        {

            var imm = _mySqlContext.Set<UserPreferenceModel>().FirstOrDefault(e => e.UserId == idUser && e.ImmobileId == idImm);
            return imm == null ? false : true;

        }

        public void addFavorite(int idUser, int idImm)
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
                string query = $"SELECT DISTINCT * FROM User u JOIN UserPreference up ON u.Id = up.userId WHERE up.immobileId = {immId} ";
                List<UserModel> users = _mySqlContext.Set<UserModel>().FromSqlRaw(query).ToList();
                users.Remove(user);
                return users;
            }
            return new List<UserModel>();
        }

        public UserModel getUserAndNotification(int userId,int notificationId)
        {
            var user = _mySqlContext.Set<UserModel>().Include(u => u.Notification.Where(n => n.Id == notificationId)).Where(u => u.Id == userId).FirstOrDefault();
            if (user != null)
            {
                
                return user;
            }
            return new UserModel();
        }


        public List<UserModel> listContacts(int userId)
        {
            var user = _mySqlContext.Set<UserModel>().FirstOrDefault();

            queryGetContacts = queryGetContacts + userId;
            List<UserModel> users = _mySqlContext.Set<UserModel>().FromSqlRaw(queryGetContacts).ToList();
            if (user != null)
            {

                return users;
            }
            return new List<UserModel>();
        }

        public bool getContact(int idUser, int idContact)
        {
             var ContactsModel = _mySqlContext.Set<ContactsModel>().Where(c => c.UserId == idUser && c.ContactId == idContact).FirstOrDefault();
             return ContactsModel == default ? false : true;
        }

        public void addContact(UserModel user, UserModel contatado)
        {
            if (contatado != null)
            {
                var contact = new ContactsModel
                {
                    User = user,
                    Contact = contatado
                };
                var contact2 = new ContactsModel
                {
                    User = contatado,
                    Contact = user
                };

                _mySqlContext.Set<ContactsModel>().Add(contact);
                _mySqlContext.Set<ContactsModel>().Add(contact2);

                _mySqlContext.SaveChanges();
            }

        }

        public void removeContact(UserModel user, UserModel contatado)
        {
            if (contatado != null)
            {
                var contact = new ContactsModel
                {
                    User = user,
                    Contact = contatado
                };
                var contact2 = new ContactsModel
                {
                    User = contatado,
                    Contact = user
                };

                _mySqlContext.Set<ContactsModel>().Remove(contact);
                _mySqlContext.Set<ContactsModel>().Remove(contact2);

                _mySqlContext.SaveChanges();
            }

        }
    }
}
