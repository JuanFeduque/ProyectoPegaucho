using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Shared.Entities;
using PegauchoBackend.Data;
using PegauchoBackend.UnitsOfWork.Interfaces;

namespace PegauchoBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : GenericController<Usuario>
{
    public UsuariosController(IGenericUnitOfWork<Usuario> unitOfWork) : base(unitOfWork)
    {
    }
}
