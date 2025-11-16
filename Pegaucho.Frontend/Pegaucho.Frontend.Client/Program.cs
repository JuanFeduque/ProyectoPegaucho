using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Pegaucho.Frontend.Client.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// ? AGREGA ESTA LÍNEA - ES LA QUE FALTA ?
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7026/")
});

builder.Services.AddMudServices();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IOrdenProduccionRepository, OrdenProduccionRepository>();

await builder.Build().RunAsync();