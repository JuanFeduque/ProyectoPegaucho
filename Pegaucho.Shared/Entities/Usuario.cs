using System.ComponentModel.DataAnnotations;

namespace Orders.Shared.Entities;

public class Usuario
{
    [Key]
    public int idLogin { get; set; }


    /*[Required(ErrorMessage = "El campo es obligatorio")]*/
    /*[MaxLength(100, ErrorMessage = "El campo no puede tener mas caracteres")]*/
    public string usuario { get; set; } = null!;
    public string contrasena { get; set; } = null!;
}

