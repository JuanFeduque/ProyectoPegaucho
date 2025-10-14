using Orders.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegaucho.Shared.Entities;

public class Produccion
{
    [Key]
    public int idOrdenProd { get; set; }
    public int idLogin { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public int codProd { get; set; }
    public string nombre { get; set; } = null!;
    public string maquinaria { get; set; } = null!;
    public string matPrima { get; set; } = null!;
    public Double cantidadLitros { get; set; }
    public string prioridad { get; set; } = null!;
    public DateTime fecha { get; set; } = DateTime.Now;
}
