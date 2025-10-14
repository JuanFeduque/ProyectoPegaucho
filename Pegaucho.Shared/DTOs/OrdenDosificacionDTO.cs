using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegaucho.Shared.DTOs;

public class OrdenDosificacionDTO
{
    public int IdOrdenDos { get; set; }

    [Required]
    public int IdOrdenPanel { get; set; }

    [Required]
    public int IdOrdenProd { get; set; }

    [Required]
    public int CodProd { get; set; }

    [MaxLength(100)]
    public string? Nombre { get; set; }

    public string? MaquinaProd { get; set; }
    public string? MatPrima { get; set; }
    public int? Cantidad { get; set; }
    public string? Prioridad { get; set; }
    public DateTime? Fecha { get; set; }
    public decimal? Costo { get; set; }
    public decimal? TiempoEstimado { get; set; }
}
