using MudBlazor.Services;
using Pegaucho.Frontend.Client.Pages;
using Pegaucho.Frontend.Client.Repositories;
using Pegaucho.Frontend.Components;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

//conecta el api y miramos la url del api
builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri("https://localhost:7026/") });

// REGISTRA AMBOS REPOSITORIOS
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IOrdenProduccionRepository, OrdenProduccionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Pegaucho.Frontend.Client._Imports).Assembly);

app.Run();