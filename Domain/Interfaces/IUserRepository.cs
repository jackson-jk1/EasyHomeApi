﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        public UserModel auth(string email);

        public bool checkImmobil(int userId, int immId);

        public void addFavorite(int idUser, int idImm);

        public void removeFavorite(int idUser, int idImm);

        public void addContact(UserModel user, UserModel contatado);
        public void removeContact(UserModel user, UserModel contatado);
       
        public List<UserModel> getUsersByImmobile(int userId, int immId);
       
        public List<UserModel> listContacts(int userId);

        public UserModel getUserAndNotification(int userId, int NotificationId);
        public bool getContact(int id, int idContact);

        public ContactsModel getContactById(int id, int idContact);
    }
}
