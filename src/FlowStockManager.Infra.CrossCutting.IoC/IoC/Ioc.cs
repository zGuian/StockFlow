using AutoMapper;
using FlowStockManager.Application.Converters;
using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.ProductApp.Command;
using FlowStockManager.Application.ProductApp.Interfaces;
using FlowStockManager.Application.ProductApp.Queries;
using FlowStockManager.Application.SupplierApp.Command;
using FlowStockManager.Application.SupplierApp.Interfaces;
using FlowStockManager.Application.SupplierApp.Queries;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
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
            services.ProductApplication();
            services.SupplierApplication();
            services.AddConvertersDI();
            services.AddRepositoriesDI();
            services.ConfigurationDataBaseRelational(configuration);
            services.ConfigurationAutoMapper();
            services.SwaggerConfiguration();
            return services;
        }

        public static IServiceCollection ProductApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateProductCommand, CreateProductCommand>();
            services.AddScoped<IDeleteProductCommand, DeleteProductCommand>();
            services.AddScoped<IGetProductByIdQuery, GetProductByIdQuery>();
            services.AddScoped<IGetProductsPageableQuery, GetProductsPageableQuery>();
            services.AddScoped<IUpdateProductCommand, UpdateProductCommand>();
            return services;
        }

        private static IServiceCollection SupplierApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateSupplierCommand, CreateSupplierCommand>();
            services.AddScoped<IDeleteSupplierCommand, DeleteSupplierCommand>();
            services.AddScoped<IGetSupplierByIdQuery, GetSupplierByIdQuery>();
            services.AddScoped<IGetSuppliersPageableQuery, GetSuppliersPageableQuery>();
            services.AddScoped<IUpdateSupplierCommand, UpdateSupplierCommand>();
            return services;
        }

        private static IServiceCollection AddRepositoriesDI(this IServiceCollection services)
        {
            services.AddScoped<IProductCommandRepository, ProductRepository>();
            services.AddScoped<IProductQueryRepository, ProductRepository>();
            services.AddScoped<ISupplierCommandRepository, SupplierRepository>();
            services.AddScoped<ISupplierQueryRepository, SupplierRepository>();
            return services;
        }

        private static IServiceCollection AddConvertersDI(this IServiceCollection services)
        {
            services.AddScoped<IProductConverter, ProductConverter>();
            services.AddScoped<ISupplierConverter, SupplierConverter>();
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
