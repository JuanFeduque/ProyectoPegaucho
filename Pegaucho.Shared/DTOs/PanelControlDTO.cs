using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pegaucho.Shared.DTOs;

public class PanelControlDTO
{
    public int IdOrdenPanel { get; set; }
    public int IdLogin { get; set; }
    public string? NombreUsuario { get; set; }
    public int TotalOrdenesProduccion { get; set; }
    public int TotalOrdenesDosificacion { get; set; }
}
