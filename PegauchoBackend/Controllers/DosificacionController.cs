using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PegauchoBackend.Data;
using Pegaucho.Shared.DTOs;
using Pegaucho.Shared.Entities;

namespace PegauchoBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DosificacionController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ILogger<DosificacionController> _logger;

    public DosificacionController(DataContext context, ILogger<DosificacionController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost("generar")]
    public async Task<IActionResult> Generar([FromBody] GenerarOrdenRequest request)
    {
        if (request == null || request.Productos == null || !request.Productos.Any())
            return BadRequest("No hay productos para generar la orden.");

        try
        {
            // Obtener un panel disponible (ajusta la lógica según tu dominio)
            var panel = await _context.PanelesControl.FirstOrDefaultAsync();
            if (panel == null)
                return BadRequest("No hay panel de control configurado.");

            // Crear cabecera de orden de producción (una por request)
            var primera = request.Productos.First();
            var ordenProduccion = new OrdenProduccion
            {
                IdOrdenPanel = panel.IdOrdenPanel,
                IdLogin = panel.IdLogin,
                codProd = primera.CodigoProducto,
                nombre = $"Orden {DateTime.Now:yyyyMMddHHmmss}",
                maquinaProd = primera.Maquinaria,
                matPrima = primera.MaterialEmpaque,
                cantidad = request.Productos.Sum(p => p.Cantidad),
                prioridad = request.Productos.FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.Prioridad))?.Prioridad,
                fecha = DateTime.Now,
                costo = request.Productos.Sum(p => p.Costo),
                tiempoEstimado = request.Productos.Select(p =>
                {
                    if (decimal.TryParse(p.TiempoEstimado, out var v)) return v;
                    return 0m;
                }).Sum()
            };

            await _context.OrdenesProduccion.AddAsync(ordenProduccion);
            await _context.SaveChangesAsync(); // para obtener IdOrdenProd

            // Crear filas de dosificación
            foreach (var p in request.Productos)
            {
                var od = new OrdenDosificacion
                {
                    IdOrdenPanel = panel.IdOrdenPanel,
                    IdOrdenProd = ordenProduccion.IdOrdenProd,
                    codProd = p.CodigoProducto,
                    nombre = p.Nombre,
                    maquinaProd = p.Maquinaria,
                    matPrima = p.MaterialEmpaque,
                    cantidad = p.Cantidad,
                    prioridad = p.Prioridad,
                    fecha = p.Fecha == default ? DateTime.Now : p.Fecha,
                    costo = p.Costo,
                    tiempoEstimado = decimal.TryParse(p.TiempoEstimado, out var t) ? t : (decimal?)null
                };
                await _context.OrdenesDosificacion.AddAsync(od);
            }

            await _context.SaveChangesAsync();

            // Retornar Created con id para referencia
            return CreatedAtAction(nameof(GetPanelOrders), new { id = ordenProduccion.IdOrdenProd }, new { ordenId = ordenProduccion.IdOrdenProd });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al generar orden de dosificación");
            return StatusCode(500, "Error interno al generar la orden. Revisa los logs.");
        }
    }

    [HttpGet("panelorders")]
    public async Task<IActionResult> GetPanelOrders()
    {
        var orders = await _context.OrdenesProduccion
            .AsNoTracking()
            .OrderByDescending(o => o.fecha)
            .Take(100)
            .ToListAsync();

        var result = orders.Select(o => new OrdenControlDTO
        {
            Orden = o.IdOrdenProd.ToString(),
            Estado = "Pendiente", // puedes mapear estado real si lo tienes
            TiempoTranscurrido = "",
            Porcentaje = "0%",
            Prioridad = o.prioridad ?? "",
            Observaciones = "",
            Fecha = o.fecha.HasValue ? o.fecha.Value.ToString("yyyy-MM-dd HH:mm:ss") : ""
        }).ToList();

        return Ok(result);
    }
}