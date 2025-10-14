using Microsoft.AspNetCore.Mvc;
using Pegaucho.Shared.Entities;
using PegauchoBackend.UnitsOfWork.Interfaces;

namespace PegauchoBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenesProduccionesController : GenericController<OrdenProduccion>
{
    public OrdenesProduccionesController(IGenericUnitOfWork<OrdenProduccion> unitOfWork) : base(unitOfWork)
    {
    }
}
