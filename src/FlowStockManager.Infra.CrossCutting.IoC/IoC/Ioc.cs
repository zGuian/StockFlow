using AutoMapper;
using FlowStockManager.Application.Handlers;
using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Application.Services;
using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Application.UseCases;
using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Interfaces;
using FlowStockManager.Infra.CrossCutting.Profiles;
using FlowStockManager.Infra.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlowStockManager.Infra.CrossCutting.IoC.IoC
{
    public static class Ioc
    {
        public static IServiceCollection IoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.DependencyInject();
            return services;
        }

        private static IServiceCollection DependencyInject(this IServiceCollection services)
        {
            #region Handler
            services.AddScoped<IProductHandler, ProductHandler>();
            #endregion Handler

            #region UseCases
            services.AddScoped<IProductUseCase, ProductUseCase>();
            #endregion UseCases

            #region Services
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
            #endregion Services

            #region Repositories
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            #endregion Repositories

            #region Database
            services.AddSingleton(ConfigurationAutoMapper);
            #endregion Database

            #region Utils
            services.AddSingleton(ConfigurationAutoMapper);
            #endregion Utils

            return services;
        }

        private static IMapper ConfigurationAutoMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProductMapper());
            });
            return mappingConfig.CreateMapper();
        }
    }
}
