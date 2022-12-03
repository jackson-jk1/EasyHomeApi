using Domain.Models;
using Domain.Utils.Result;
using Domain.ViewModels.Response.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IFiltrosService : IDisposable
    {
        Task<Result<List<PoloResponse>>> GetAllPolos();

        Task<Result<List<UserModel>>> GetAllBairros();
    }
}
