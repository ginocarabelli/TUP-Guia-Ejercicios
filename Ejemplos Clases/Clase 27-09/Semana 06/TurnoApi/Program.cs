using Microsoft.EntityFrameworkCore;
using TurnoApi.Models;
using TurnoApi.Repositorios;
using TurnoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TurnosDbContext>(options =>
options
.UseSqlServer(builder.Configuration
.GetConnectionString("DefaultConnection")));//Inyecta la conexion con un scoped.

builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();//crea una nueva instancia por cada request
//builder.Services.AddTransient<ITurnoService, TurnoService>();//crea siempre una instancia nueva
//builder.Services.AddSingleton<ITurnoService, TurnoService>();//crea una sola instancia para toda la aplicacion
builder.Services.AddScoped<ITurnoService, TurnoService>();
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
