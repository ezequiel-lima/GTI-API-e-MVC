using GTI.Infra;
using GTI.Infra.Data.Interfaces;
using GTI.Infra.Data;
using Microsoft.EntityFrameworkCore;
using GTI.Domain.Entities;
using GTI.Application.Interfaces;
using GTI.Shared.Handlers;
using GTI.Application.Handlers;
using GTI.Domain.Commands.Clientes;
using GTI.Application.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<GTIDataContext>(options =>
    {
        options.UseSqlServer(connectionString, x => x.MigrationsAssembly("GTI.Infra"));
    });

    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyMethod()
            .AllowAnyOrigin()
            .AllowAnyHeader();
        });
    });

    var services = GetServiceCollection(builder);
}

IServiceCollection GetServiceCollection(WebApplicationBuilder builder)
{
    // Adicionando servi�os
    var services = builder.Services;
    services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

    services.AddScoped<IReadRepository<Cliente>, ApplicationRepository<Cliente>>();
    services.AddScoped<IWriteRepository<Cliente>, ApplicationRepository<Cliente>>();

    services.AddScoped<IReadRepository<Endereco>, ApplicationRepository<Endereco>>();
    services.AddScoped<IWriteRepository<Endereco>, ApplicationRepository<Endereco>>();

    services.AddScoped<IClienteService, ClienteService>();
    services.AddScoped<IEnderecoService, EnderecoService>();

    services.AddScoped<IHandler<CreateClienteCommand>, CreateClienteHandler>();
    services.AddScoped<IHandler<UpdateClienteCommand>, UpdateClienteHandler>();

    return services;
}