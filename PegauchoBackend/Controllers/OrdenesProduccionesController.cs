using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pegaucho.Shared.DTOs;
using Pegaucho.Shared.Entities;
using PegauchoBackend.Data;

namespace PegauchoBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenesProduccionesController : ControllerBase
{
    private readonly DataContext _context;
    private readonly ILogger<OrdenesProduccionesController> _logger;

    public OrdenesProduccionesController(DataContext context, ILogger<OrdenesProduccionesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost("generar")]
    public async Task<IActionResult> Generar([FromBody] GenerarProduccionRequest request)
    {
        if (request == null || request.Ordenes == null || !request.Ordenes.Any())
            return BadRequest("No hay órdenes para generar.");

        try
        {
            var panel = await _context.PanelesControl.FirstOrDefaultAsync();
            if (panel == null)
                return BadRequest("No hay panel de control configurado.");

            // Crear una cabecera de orden de produccion que agrupe las ordenes enviadas
            var primera = request.Ordenes.First();
            var ordenProduccionCab = new OrdenProduccion
            {
                IdOrdenPanel = panel.IdOrdenPanel,
                IdLogin = panel.IdLogin,
                codProd = primera.CodProd,
                nombre = $"Prod {DateTime.Now:yyyyMMddHHmmss}",
                maquinaProd = primera.MaquinaProd,
                matPrima = primera.MatPrima,
                cantidad = request.Ordenes.Sum(x => x.Cantidad) ?? 0,
                prioridad = request.Ordenes.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.Prioridad))?.Prioridad,
                fecha = DateTime.Now,
                costo = request.Ordenes.Sum(x => x.Costo) ?? 0,
                tiempoEstimado = request.Ordenes.Sum(x => x.TiempoEstimado) ?? 0
            };

            await _context.OrdenesProduccion.AddAsync(ordenProduccionCab);
            await _context.SaveChangesAsync();

            // Opcional: crear registros OrdenDosificacion por cada OrdenProduccionDTO
            foreach (var o in request.Ordenes)
            {
                var od = new OrdenDosificacion
                {
                    IdOrdenPanel = panel.IdOrdenPanel,
                    IdOrdenProd = ordenProduccionCab.IdOrdenProd,
                    codProd = o.CodProd,
                    nombre = o.Nombre,
                    maquinaProd = o.MaquinaProd,
                    matPrima = o.MatPrima,
                    cantidad = o.Cantidad,
                    prioridad = o.Prioridad,
                    fecha = o.Fecha ?? DateTime.Now,
                    costo = o.Costo,
                    tiempoEstimado = o.TiempoEstimado
                };
                await _context.OrdenesDosificacion.AddAsync(od);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = ordenProduccionCab.IdOrdenProd }, new { ordenId = ordenProduccionCab.IdOrdenProd });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al generar ordenes de produccion");
            return StatusCode(500, "Error interno al generar las órdenes.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var orden = await _context.OrdenesProduccion.FindAsync(id);
        if (orden == null) return NotFound();
        return Ok(orden);
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
            Estado = "Pendiente",
            TiempoTranscurrido = "",
            Porcentaje = "0%",
            Prioridad = o.prioridad ?? "",
            Observaciones = "",
            Fecha = o.fecha.HasValue ? o.fecha.Value.ToString("yyyy-MM-dd HH:mm:ss") : ""
        }).ToList();

        return Ok(result);
    }
}
