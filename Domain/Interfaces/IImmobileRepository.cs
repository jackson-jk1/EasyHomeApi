using Domain.Models;
using Domain.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IImmobileRepository : IBaseRepository<ImmobileModel>
    {
        public List<ImmobileModel> getByFilters(FilterRequest filters);

        public List<ImmobileModel> getByUser(int id);
        
    }
}
