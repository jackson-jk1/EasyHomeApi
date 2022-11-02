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
    }
}
