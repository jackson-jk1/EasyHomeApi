using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Base;
using Domain.Utils.Result;
using Domain.ViewModels.Request;
using Domain.ViewModels.Response;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using System.Text.Json;

namespace Service.Services
{
    public class ImmobileService : IImmobileService
    {
        private readonly IMapper _mapper;
        private readonly IImmobileRepository _immobileRepository;
        private readonly IBaseRepository<PoloModel> _poloRepository;

        public ImmobileService(IMapper mapper, IImmobileRepository immobileRepository, IBaseRepository<PoloModel> poloRepository)
        {
    
            _mapper = mapper;
            _immobileRepository = immobileRepository;
        }
        public void Dispose()
        {
            return;
        }

        public async Task<Result<PaginatedListModel<ImmobileResponse>>> GetAllImmobiles(int pageNumber = 1)
        {
            var response = _immobileRepository.Select().ToList();
            List<ImmobileResponse> immobiles = new List<ImmobileResponse>();

            response.ForEach(res =>
            {
                var imm = _mapper.Map<ImmobileResponse>(res);
                imm.Imgs = JsonSerializer.Deserialize<List<string>>(res.Images)!;
                immobiles.Add(imm);
            });
           

            return new CustomResult<PaginatedListModel<ImmobileResponse>>(200)
            {
                Data = await PaginatedListModel<ImmobileResponse>.CreateAsync(immobiles.AsQueryable().AsNoTracking(), pageNumber, 10)
            };
            
        }

        public async Task<Result<PaginatedListModel<ImmobileResponse>>> GetImmobiles(FilterRequest filters)
        {

            var response = _immobileRepository.getByFilters(filters);


            List<ImmobileResponse> immobiles = new List<ImmobileResponse>();

            response.ForEach(res =>
            {
                var imm = _mapper.Map<ImmobileResponse>(res);
                imm.Imgs = JsonSerializer.Deserialize<List<string>>(res.Images)!;
                immobiles.Add(imm);
            });


            return new CustomResult<PaginatedListModel<ImmobileResponse>>(200)
            {
                Data = await PaginatedListModel<ImmobileResponse>.CreateAsync(immobiles.AsQueryable().AsNoTracking(), filters.Page, 10)
            };

        }


    }
}
