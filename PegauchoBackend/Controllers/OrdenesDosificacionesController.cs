using Microsoft.AspNetCore.Mvc;
using Pegaucho.Shared.Entities;
using PegauchoBackend.UnitsOfWork.Interfaces;

namespace PegauchoBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenesDosificacionesController : GenericController<OrdenDosificacion>
{
    public OrdenesDosificacionesController(IGenericUnitOfWork<OrdenDosificacion> unitOfWork) : base(unitOfWork)
    {
    }
}
