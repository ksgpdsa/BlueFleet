using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.IRepositories;
using Infra.Data.Data;
using Infra.Data.Interfaces;
using Infra.Data.Repositories;
using Infra.Data.Transactions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMap));
            services.AddAutoMapper(typeof(DtoToDomainMap));
            services.AddScoped<IVeiculoApiService, VeiculoApiService>();

            return services;
        }
    }
}
