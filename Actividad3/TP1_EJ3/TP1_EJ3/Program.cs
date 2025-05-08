using Microsoft.EntityFrameworkCore;
using CDatos.Data;
using CDatos.Repositorios.IRepo;
using CDatos.Repositorios.Repositorios;
using CNegocio.Logica.ILogica;
using CNegocio.Logica;

var builder = WebApplication.CreateBuilder(args);

// 👇 Registro de servicios
builder.Services.AddScoped<IAnimalsLogic, AnimalsLogic>();
builder.Services.AddScoped<IAnimalsRepositorio, AnimalsRepositorio>();

builder.Services.AddScoped<IOwnersLogic, OwnersLogic>();
builder.Services.AddScoped<IOwnersRepositorio, OwnersRepositorio>();

builder.Services.AddScoped<IAttentionsLogic, AttentionsLogic>();
builder.Services.AddScoped<IAtentionRepositorio, AttentionsRepositorio>();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Configuración Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de Kestrel para HTTP y HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5202); // HTTP
    options.ListenLocalhost(7005, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
