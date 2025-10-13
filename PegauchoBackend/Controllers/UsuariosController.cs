using Microsoft.AspNetCore.Mvc;
using Orders.Shared.Entities;
using PegauchoBackend.Data;

namespace PegauchoBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly DataContext _context;

    public UsuariosController(DataContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task <IActionResult> PostAsync(Usuario usuario) 
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return Ok(usuario);
    }
}
