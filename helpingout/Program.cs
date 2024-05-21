using helpingout.Data;
using helpingout.Interfaces;
using helpingout.Repositories; // Certifique-se de ter a implementação do repositório
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("ServidorDB"));

// Adiciona o repositório de usuário
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(); // Certifique-se de ter a implementação do repositório

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
