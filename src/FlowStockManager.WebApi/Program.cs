using FlowStockManager.Infra.CrossCutting.IoC.IoC;
using FlowStockManager.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.IoC(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionsFilter)));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opts =>
    {
        opts.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        opts.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
    });
}
app.UseStaticFiles();
app.MapControllers();
app.Run();
