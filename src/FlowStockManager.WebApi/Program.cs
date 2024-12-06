using FlowStockManager.Infra.CrossCutting.IoC.IoC;
using FlowStockManager.WebApi.Middlewares;

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
app.UseStaticFiles();
app.MapControllers();
app.Run();
