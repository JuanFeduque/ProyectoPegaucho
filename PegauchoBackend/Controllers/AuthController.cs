using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PegauchoBackend.Data;
using Pegaucho.Shared.DTOs;
using Orders.Shared.Entities;

namespace PegauchoBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly DataContext _context;

    public AuthController(DataContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO loginDto)
    {
        if (loginDto == null || string.IsNullOrWhiteSpace(loginDto.Usuario) || string.IsNullOrWhiteSpace(loginDto.Contrasena))
        {
            return BadRequest("Usuario y contraseña son requeridos.");
        }

        var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.usuario == loginDto.Usuario);
        if (user == null)
        {
            return BadRequest("Usuario o contraseña inválidos.");
        }

        // EN PRODUCCIÓN: comparar hash de contraseña
        if (user.contrasena != loginDto.Contrasena)
        {
            return BadRequest("Usuario o contraseña inválidos.");
        }

        // Retornar información mínima
        return Ok(new { user.IdLogin, user.usuario });
    }
}
