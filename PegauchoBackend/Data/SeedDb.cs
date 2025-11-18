
using Microsoft.EntityFrameworkCore;
using Orders.Shared.Entities;
using Pegaucho.Shared.Entities;

namespace PegauchoBackend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckUsuariosAsync();
        await CheckPanelesControlAsync();
    }

    private async Task CheckUsuariosAsync()
    {
        if (!_context.Usuarios.Any())
        {
            _context.Usuarios.Add(new Usuario
            {
                usuario = "admin",
                contrasena = "123456" // ⚠️ En producción usar hash
            });

            _context.Usuarios.Add(new Usuario
            {
                usuario = "planta",
                contrasena = "123456"
            });

            _context.Usuarios.Add(new Usuario
            {
                usuario = "supervisor",
                contrasena = "123456"
            });

            await _context.SaveChangesAsync();
        }
    }

    private async Task CheckPanelesControlAsync()
    {
        if (!_context.PanelesControl.Any())
        {
            // Obtener los usuarios creados
            var usuarios = await _context.Usuarios.ToListAsync();

            // Crear paneles de control para cada usuario
            foreach (var usuario in usuarios)
            {
                _context.PanelesControl.Add(new PanelControl
                {
                    IdLogin = usuario.IdLogin
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
