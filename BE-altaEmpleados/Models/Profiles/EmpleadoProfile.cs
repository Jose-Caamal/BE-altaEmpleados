using AutoMapper;
using BE_altaEmpleados.Models.DTO;

namespace BE_altaEmpleados.Models.Profiles
{
    public class EmpleadoProfile : Profile
    {
        public EmpleadoProfile()
        {
            CreateMap<Empleado, EmpleadoDTO>();
            CreateMap<EmpleadoDTO , Empleado>();
        }
    }
}
