using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegaucho.Shared.Entities;

public class OrdenDosificacion
{
    [Key]
    public int IdOrdenDos { get; set; }

    public int IdOrdenPanel { get; set; }
    public int IdOrdenProd { get; set; }

    public int codProd { get; set; }
    public string? nombre { get; set; }
    public string? maquinaProd { get; set; }
    public string? matPrima { get; set; }
    public int? cantidad { get; set; }
    public string? prioridad { get; set; }
    public DateTime? fecha { get; set; }
    public decimal? costo { get; set; }
    public decimal? tiempoEstimado { get; set; }

    public PanelControl PanelControl { get; set; } = null!;
    public OrdenProduccion OrdenProduccion { get; set; } = null!;
}