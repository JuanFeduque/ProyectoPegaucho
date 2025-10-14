using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegaucho.Shared.DTOs;

public class UsuarioDTO
{
    public int IdLogin { get; set; }

    [Required(ErrorMessage = "El usuario es obligatorio")]
    [MaxLength(50)]
    public string Usuario { get; set; } = null!;
}

public class UsuarioCreateDTO
{
    [Required(ErrorMessage = "El usuario es obligatorio")]
    [MaxLength(50, ErrorMessage = "Máximo 50 caracteres")]
    public string Usuario { get; set; } = null!;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    [MinLength(6, ErrorMessage = "Mínimo 6 caracteres")]
    public string Contrasena { get; set; } = null!;
}

public class UsuarioLoginDTO
{
    [Required(ErrorMessage = "El usuario es obligatorio")]
    public string Usuario { get; set; } = null!;

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string Contrasena { get; set; } = null!;
}
