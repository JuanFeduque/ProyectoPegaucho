using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Pegaucho.Frontend.Client.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IOrdenProduccionRepository, OrdenProduccionRepository>();

await builder.Build().RunAsync();