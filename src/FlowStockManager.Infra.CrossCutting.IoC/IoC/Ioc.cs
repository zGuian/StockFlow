using AutoMapper;
using FlowStockManager.Application.Handlers;
using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Application.Services;
using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Application.UseCases;
using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Interfaces;
using FlowStockManager.Infra.CrossCutting.Configuration;
using FlowStockManager.Infra.CrossCutting.Profiles;
using FlowStockManager.Infra.Data.Context;
using FlowStockManager.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlowStockManager.Infra.CrossCutting.IoC.IoC
{
    public static class Ioc
    {
        public static IServiceCollection IoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.DependencyInject(configuration);
            services.SwaggerConfiguration();
            return services;
        }

        private static IServiceCollection DependencyInject(this IServiceCollection services, IConfiguration configuration)
        {
            #region Handler
            services.AddScoped<IProductHandler, ProductHandler>();
            services.AddScoped<ISupplierHandler, SupplierHandler>();
            services.AddScoped<IOrderHandler, OrderHandler>();
            #endregion Handler

            #region UseCases
            services.AddScoped<IProductUseCase, ProductUseCase>();
            services.AddScoped<ISupplierUseCase, SupplierUseCase>();
            services.AddScoped<IOrderUseCase, OrderUseCase>();
            #endregion UseCases

            #region Services
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IOrderService, OrderService>();
            #endregion Services

            #region Repositories
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            #endregion Repositories

            #region Database
            services.ConfigurationDataBaseRelational(configuration);
            #endregion Database

            #region Utils
            services.ConfigurationAutoMapper();
            #endregion Utils

            return services;
        }

        private static IServiceCollection ConfigurationDataBaseRelational(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(opts =>
                opts.UseNpgsql(configuration.GetConnectionString("PostgreSql")));
        }

        private static IServiceCollection ConfigurationAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProductMapper());
                mc.AddProfile(new SupplierMapper());
            });
            return services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
