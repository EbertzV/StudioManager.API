using StudioManager.Application.CancelarReserva;
using StudioManager.Application.ReservarHorario;
using StudioManager.Domain.Reservas;
using StudioManager.Domain.Reservas.Clientes;
using StudioManager.Infra.SqlServer.Context;
using StudioManager.Infra.SqlServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ReservasContext>();
builder.Services.AddScoped<IClientesRepositorio, ClientesRepositorio>();
builder.Services.AddScoped<IReservasRepositorio, ReservasRepositorio>();
builder.Services.AddScoped<IReservarHorarioCommandHandler, ReservarHorarioCommandHandler>();
builder.Services.AddScoped<ICancelarReservaAplicacao, CancelarReservaAplicacao>();

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
