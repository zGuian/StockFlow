using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace FlowStockManager.Infra.CrossCutting.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection SwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Controle de Estoque, Pedidos e Logística - StockFlow",
                    Description = "API de um projeto gerado pelo ChatGPT para estudos. Ele fazendo a função de meu PO e me passando demandas",
                    Contact = new OpenApiContact
                    {
                        Name = "Guian Rocha",
                        Email = "guianmarcos32@icloud.com",
                    }
                });
            });
            return services;
        }
    }
}
