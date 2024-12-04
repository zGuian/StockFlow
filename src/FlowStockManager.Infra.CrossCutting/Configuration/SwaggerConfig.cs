using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FlowStockManager.Infra.CrossCutting.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection SwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc("v1", GetApiInfo("v1"));
            });
            return services;
        }

        private static OpenApiInfo GetApiInfo(string version)
        {
            return new OpenApiInfo
            {
                Version = version,
                Title = "Controle de Estoque, Pedidos e Logística - StockFlow",
                Description = "API de um projeto gerado pelo ChatGPT para estudos. Ele fazendo a função de meu PO e me passando demandas",
                Contact = new OpenApiContact
                {
                    Name = "Guian Rocha",
                    Email = "guianmarcos32@icloud.com",
                }
            };
        }
    }
}
