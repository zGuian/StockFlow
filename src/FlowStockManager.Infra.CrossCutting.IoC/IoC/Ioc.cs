using AutoMapper;
using FlowStockManager.Application.Converters;
using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.ProductApp.Command;
using FlowStockManager.Application.ProductApp.Interfaces;
using FlowStockManager.Application.ProductApp.Queries;
using FlowStockManager.Application.SupplierApp.Command;
using FlowStockManager.Application.SupplierApp.Interfaces;
using FlowStockManager.Application.SupplierApp.Queries;
using FlowStockManager.Application.UserApp.Command;
using FlowStockManager.Application.UserApp.Interfaces;
using FlowStockManager.Application.UserApp.Queries;
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
            services.UserApplication();
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

        private static IServiceCollection UserApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserCommand, CreateUserCommand>();
            services.AddScoped<IUpdateUserCommand, UpdateUserCommand>();
            services.AddScoped<IDisableUserCommand, DisableUserCommand>();
            services.AddScoped<IGetUserByIdQuery, GetUserByIdQuery>();
            return services;
        }

        private static IServiceCollection AddRepositoriesDI(this IServiceCollection services)
        {
            services.AddScoped<IProductCommandRepository, ProductRepository>();
            services.AddScoped<IProductQueryRepository, ProductRepository>();

            services.AddScoped<ISupplierCommandRepository, SupplierRepository>();
            services.AddScoped<ISupplierQueryRepository, SupplierRepository>();

            services.AddScoped<IUserCommandRepository, UserRepository>();
            services.AddScoped<IUserQueryRepository, UserRepository>();
            return services;
        }

        private static IServiceCollection AddConvertersDI(this IServiceCollection services)
        {
            services.AddScoped<IProductConverter, ProductConverter>();
            services.AddScoped<ISupplierConverter, SupplierConverter>();
            services.AddScoped<IUserConverter, UserConverter>();
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
                mc.AddProfile(new UserMapper());
            });
            return services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
