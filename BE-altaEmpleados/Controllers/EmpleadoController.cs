using AutoMapper;
using BE_altaEmpleados.Models;
using BE_altaEmpleados.Models.DTO;
using BE_altaEmpleados.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_altaEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class empleadoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmpleadoRepository _empleadoRepository;

        public empleadoController( IMapper mapper , IEmpleadoRepository empleadoRepository)
        {
            _mapper = mapper;
            _empleadoRepository = empleadoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listEmpleado = await _empleadoRepository.GetListEmpleado();

                var listEmpleadoDTO = _mapper.Map<IEnumerable<EmpleadoDTO>>(listEmpleado);
                return Ok(listEmpleadoDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var empleado = await _empleadoRepository.GetEmpleado(id);
                if (empleado == null)
                {
                    return NotFound();
                }
                var empleadoDTO = _mapper.Map<EmpleadoDTO>(empleado);
                return Ok(empleadoDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var empleado = await _empleadoRepository.GetEmpleado(id);

                if (empleado == null)
                {
                    return NotFound();
                }
                await _empleadoRepository.DeleteEmpleado(empleado);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Empleado empleado)
        {
            try
            {
                empleado.cargo = null;
                await _empleadoRepository.AddEmpleado(empleado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Empleado empleado)
        {
            try
            {
                if (id != empleado.id)
                {
                    return BadRequest();
                }

                var empleadoitem = await _empleadoRepository.GetEmpleado(id);

                if (empleadoitem == null)
                {
                    return NotFound();
                }
                await _empleadoRepository.UpdateEmlpeado(empleado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("estatus/{id}")]
        public async Task<IActionResult> PutEstatus(int id, bool nuevoEstatus)
        {

            var empleado = await _empleadoRepository.GetEmpleado(id);
            if (empleado == null)
            {
                return NotFound();
            }
            await _empleadoRepository.UpdateEmlpeadoEstatus(empleado);
            return Ok();
        }


    }
}
