using Service.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations
{
    public static class AutoMapperConfig
    {
      
            public static void AddAutoMapperConfiguration(this IServiceCollection services)
            {
              
            
                services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
                services.AddAutoMapper(typeof(ViewModelToDomainMappingProfile), typeof(DomainToViewModelMappingProfile));
            }
        
    }
}
