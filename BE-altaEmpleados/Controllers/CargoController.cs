using BE_altaEmpleados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_altaEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cargoController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public cargoController(AplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCargo = await _context.cargo.ToListAsync();
                return Ok(listCargo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
