using Microsoft.AspNetCore.Mvc;
using Pegaucho.Shared.Entities;
using PegauchoBackend.UnitsOfWork.Interfaces;

namespace PegauchoBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PanelesControladoresController : GenericController<PanelControl>
{
    public PanelesControladoresController(IGenericUnitOfWork<PanelControl> unitOfWork) : base(unitOfWork)
    {
    }
}