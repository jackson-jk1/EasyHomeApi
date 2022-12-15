using Domain.Models;
using Domain.Models.Base;
using Domain.Utils.Result;
using Domain.ViewModels.Request;
using Domain.ViewModels.Response;
using Domain.ViewModels.Response.Auth;
using Microsoft.AspNetCore.Http;

namespace Service.Interfaces
{
    public interface IImmobileService : IDisposable
    
    {
        Task<Result<PaginatedListModel<ImmobileResponse>>> GetImmobiles(FilterRequest filters);
      
    }
}
