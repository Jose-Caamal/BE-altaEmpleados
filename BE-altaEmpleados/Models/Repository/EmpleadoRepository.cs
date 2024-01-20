
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_altaEmpleados.Models.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AplicationDbContext _context;

        public EmpleadoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Empleado>> GetListEmpleado()
        {
           return await _context.datosEmpleado.Include(e => e.cargo).ToListAsync();
        }

        public async Task<Empleado> GetEmpleado(int id)
        {
            return await _context.datosEmpleado.Include(c => c.cargo).Where(c => c.id == id).FirstOrDefaultAsync();
        }

        public async Task DeleteEmpleado(Empleado empleado)
        {
            _context.datosEmpleado.Remove(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task<Empleado> AddEmpleado(Empleado empleado)
        {
            _context.Add(empleado);
            await _context.SaveChangesAsync();
            return empleado;
        }

        public async Task UpdateEmlpeado(Empleado empleado)
        {
            var empleadoitem = await _context.datosEmpleado.FirstOrDefaultAsync(x => x.id == empleado.id);

            if (empleadoitem != null)
            {
                empleadoitem.nombreCompleto = empleado.nombreCompleto;
                empleadoitem.edad = empleado.edad;
                empleadoitem.fechaNacimiento = empleado.fechaNacimiento;
                empleadoitem.idCargo = empleado.idCargo;
                empleadoitem.estatus = empleado.estatus;

                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateEmlpeadoEstatus(Empleado empleado)
        {
            var empleadoitem = await _context.datosEmpleado.FirstOrDefaultAsync(x => x.id == empleado.id);

            if (empleadoitem != null)
            {
                bool nuevoEstatus = empleado.estatus ? false : true;
                empleadoitem.estatus = nuevoEstatus;

                await _context.SaveChangesAsync();
            }
        }

        // Cargo

        public async Task<Cargo> GetCargo(Empleado empleado)
        {
            return await _context.cargo.FindAsync(empleado.idCargo);
        }


    }
}
