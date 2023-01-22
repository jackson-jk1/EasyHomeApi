using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Domain.ViewModels.Request;
using Domain.ViewModels.Response.Auth;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Data.Repository
{
    public class ImmobileRepository : BaseRepository<ImmobileModel>, IImmobileRepository
    {
        public ImmobileRepository(MySqlContext mySqlContext) : base(mySqlContext)
        {
        }

        public List<ImmobileModel> getByFilters(FilterRequest filters)
        {
            var polo = _mySqlContext.Set<PoloModel>().Where(p => p.Name == filters.Polo).FirstOrDefault();
            IEnumerable<ImmobileModel> list = new List<ImmobileModel>();
            if (polo != null)
            {
                string query = $"select immo.* from Immobile immo, Bairro b, BairrosPolo bp, Polo p where immo.in_use = true and immo.bairroId = b.Id and bp.bairroId = b.Id and p.Id = bp.poloId and p.Name = '{polo.Name}';";

                list = _mySqlContext.Set<ImmobileModel>().FromSqlRaw(query);
            }
            else
            {
                list = _mySqlContext.Set<ImmobileModel>().Where(i => i.IsActive == true);
            }
                if (filters.ValueMax > 0)
                {
                    list = list.Where(i => i.Price <= filters.ValueMax);
                }
                 if (filters.Rooms > 0)
                {
                    list = list.Where(i => i.Rooms <= filters.Rooms);
                }
                return list.ToList();
        }

        public List<ImmobileModel> getByUser(int id)
        {
 
                string query = $"select immo.* from Immobile immo, UserPreference up where immo.Id = up.immobileId and up.userId = '{id}';";

                return _mySqlContext.Set<ImmobileModel>().
                   FromSqlRaw(query).ToList();
         
        }

    }
}
