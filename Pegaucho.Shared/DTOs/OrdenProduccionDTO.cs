using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegaucho.Shared.DTOs;

public class OrdenProduccionDTO
{
    public int IdOrdenProd { get; set; }
    public int IdOrdenPanel { get; set; }
    public int IdLogin { get; set; }

    [Required(ErrorMessage = "El código del producto es obligatorio")]
    public int CodProd { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MaxLength(100)]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "Debe seleccionar una maquinaria")]
    public string? MaquinaProd { get; set; }

    [Required(ErrorMessage = "Debe seleccionar una materia prima")]
    public string? MatPrima { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public int? Cantidad { get; set; }

    [Required(ErrorMessage = "Debe seleccionar una prioridad")]
    public string? Prioridad { get; set; }

    public DateTime? Fecha { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El costo no puede ser negativo")]
    public decimal? Costo { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "El tiempo no puede ser negativo")]
    public decimal? TiempoEstimado { get; set; }
}
