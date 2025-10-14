using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [HttpGet]
    public async Task <IActionResult> GetAsync() 
    {
        return Ok(await _context.Usuarios.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return Ok(usuario);
    }
}
