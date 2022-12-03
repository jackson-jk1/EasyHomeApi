using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Utils.Result;
using Domain.ViewModels.Response.Auth;
using Domain.ViewModels.Response.Filtros;
using Microsoft.AspNetCore.Hosting;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FiltrosService : IFiltrosService
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<PoloModel> _poloRepository;

        public FiltrosService(IHostingEnvironment environment, IMapper mapper, IBaseRepository<PoloModel> poloRepository)
        {
            _appEnvironment = environment;
            _mapper = mapper;
            _poloRepository = poloRepository;
        }
        public void Dispose()
        {
            return;
        }

        public Task<Result<List<UserModel>>> GetAllBairros()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<PoloResponse>>> GetAllPolos()
        {
            List<PoloResponse> polos = new List<PoloResponse>();
            var response = _poloRepository.Select();
            response.ToList().ForEach(p => {
                polos.Add(_mapper.Map<PoloResponse>(p));
            });


            return new CustomResult<List<PoloResponse>>(200)
            {
                Data = polos
            };
        }
    }
}
