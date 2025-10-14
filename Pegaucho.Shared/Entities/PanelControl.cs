using Orders.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pegaucho.Shared.Entities;

public class PanelControl
{
    [Key]
    public int IdOrdenPanel { get; set; }

    public int IdLogin { get; set; }

    public Usuario Usuario { get; set; } = null!;

    [JsonIgnore]
    public ICollection<OrdenProduccion> OrdenesProduccion { get; set; } = new List<OrdenProduccion>();

    [NotMapped]
    public int OrdenesProduccionesNumber => OrdenesProduccion?.Count ?? 0;

    [JsonIgnore]
    public ICollection<OrdenDosificacion> OrdenesDosificaciones { get; set; } = new List<OrdenDosificacion>();

    [NotMapped]
    public int OrdenesDosificacionesNumber => OrdenesDosificaciones?.Count ?? 0;
}
