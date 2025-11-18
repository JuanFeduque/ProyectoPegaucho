using System;
using System.Collections.Generic;

namespace Pegaucho.Shared.DTOs;

public class DosificacionDTO
{
    public int CodigoProducto { get; set; }
    public string Nombre { get; set; } = "";
    public int Cantidad { get; set; }
    public string Prioridad { get; set; } = "";
    public string Maquinaria { get; set; } = "";
    public string MaterialEmpaque { get; set; } = "";
    public string TiempoEstimado { get; set; } = "";
    public decimal Costo { get; set; }
    public DateTime Fecha { get; set; }
}

public class GenerarOrdenRequest
{
    public List<DosificacionDTO> Productos { get; set; } = new List<DosificacionDTO>();
    // Opcional: IdLogin, IdOrdenPanel, metadata, etc.
}

public class OrdenControlDTO
{
    public string Orden { get; set; } = "";
    public string Estado { get; set; } = "";
    public string TiempoTranscurrido { get; set; } = "";
    public string Porcentaje { get; set; } = "";
    public string Prioridad { get; set; } = "";
    public string Observaciones { get; set; } = "";
    public string Fecha { get; set; } = ""; // fecha para mostrar en panel
}