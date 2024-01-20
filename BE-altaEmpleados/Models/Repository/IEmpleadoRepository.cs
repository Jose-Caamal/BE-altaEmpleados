using Microsoft.AspNetCore.SignalR;

namespace BE_altaEmpleados.Models.Repository
{
    public interface IEmpleadoRepository
    {
        Task<List<Empleado>> GetListEmpleado();
        Task<Empleado> GetEmpleado(int id);
        Task DeleteEmpleado(Empleado empleado);
        Task<Empleado> AddEmpleado(Empleado empleado);
        Task UpdateEmlpeado(Empleado empleado);

        Task UpdateEmlpeadoEstatus(Empleado empleado);

        //Cargo

        Task<Cargo> GetCargo(Empleado empleado);
    }
}
