using Orders.Shared.Entities;
using Pegaucho.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pegaucho.Shared.Entities;

public class OrdenProduccion : IEntityWithName
{
    [Key]
    public int IdOrdenProd { get; set; }

    public int IdOrdenPanel { get; set; }
    public int IdLogin { get; set; }

    public int codProd { get; set; }
    public string? nombre { get; set; }
    public string? maquinaProd { get; set; }
    public string? matPrima { get; set; }
    public int? cantidad { get; set; }
    public string? prioridad { get; set; }
    public DateTime? fecha { get; set; }
    public decimal? costo { get; set; }
    public decimal? tiempoEstimado { get; set; }

    // Implementación de IEntityWithName
    [NotMapped]
    public string Name
    {
        get => nombre ?? string.Empty;
        set => nombre = value;
    }

    public Usuario Usuario { get; set; } = null!;
    public PanelControl PanelControl { get; set; } = null!;

    [JsonIgnore]
    public ICollection<OrdenDosificacion> OrdenesDosificaciones { get; set; } = new List<OrdenDosificacion>();

    [NotMapped]
    public int OrdenesDosificacionesNumber => OrdenesDosificaciones?.Count ?? 0;
}
