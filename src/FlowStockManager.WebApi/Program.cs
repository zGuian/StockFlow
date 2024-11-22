using FlowStockManager.WebApi.Middlewares;
using FlowStockManager.Infra.CrossCutting.IoC.IoC;

var builder = WebApplication.CreateBuilder(args);
builder.Services.IoC(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.Run();
