using Microsoft.EntityFrameworkCore;
using PegauchoBackend.Data;
using PegauchoBackend.Repositories.Implementations;
using PegauchoBackend.Repositories.Interfases;
using PegauchoBackend.UnitsOfWork.Implementations;
using PegauchoBackend.UnitsOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS configuration
builder.Services.AddCors(options =>
{
    // Permitir orígenes específicos (frontends y backend) - usar en producción
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins(
                "https://localhost:7064",  // Frontend HTTPS
                "http://localhost:5064",   // Frontend HTTP
                "https://localhost:7026",  // Backend/Swagger HTTPS (ajusta puerto si es necesario)
                "http://localhost:7026"    // Backend/Swagger HTTP
            )
            .AllowAnyMethod()
            .AllowAnyHeader();
            // .AllowCredentials(); // NO usar AllowCredentials con AllowAnyOrigin
    });

    // Política de desarrollo abierta para debugging local (NO usar en producción)
    options.AddPolicy("AllowAllDev", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Database
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));
builder.Services.AddTransient<SeedDb>();

// Repositories and UnitOfWork
builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Seed data
SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar CORS antes de Authorization y MapControllers
// En desarrollo usa la política abierta para evitar problemas de CORS/scheme con Swagger y Blazor
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAllDev");
}
else
{
    app.UseCors("AllowBlazorClient");
}

app.UseAuthorization();
app.MapControllers();

app.Run();