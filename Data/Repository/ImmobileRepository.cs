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

            if (polo != null) {
                if (filters.ValueMax > 0 && filters.Rooms > 0)
                {
                    return _mySqlContext.Set<ImmobileModel>().Where(i => i.Price <= filters.ValueMax && i.Rooms <= filters.Rooms).ToList();
                }
                if (filters.ValueMax > 0)
                {
                    return _mySqlContext.Set<ImmobileModel>().Where(i => i.Price <= filters.ValueMax).ToList();
                }
                if (filters.Rooms > 0)
                {
                    return _mySqlContext.Set<ImmobileModel>().Where(i => i.Rooms <= filters.Rooms).ToList();
                }
                string query = $"select immo.* from Immobile immo, Bairro b, BairrosPolo bp, Polo p where immo.bairroId = b.Id and bp.bairroId = b.Id and p.Id = bp.poloId and p.Name = '{polo.Name}';";
    
                return _mySqlContext.Set<ImmobileModel>().
                   FromSqlRaw(query).ToList();
            }

            return _mySqlContext.Set<ImmobileModel>().ToList();
        }

    }
}
