using System.ComponentModel.DataAnnotations.Schema;

namespace BE_altaEmpleados.Models
{
    public class Empleado
    {
        public int id { get; set; }
        public string nombreCompleto { get; set; }
        public int edad { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public bool estatus { get; set; }

        public int? idCargo { get; set; }

        [ForeignKey("idCargo")]
        public virtual Cargo cargo { get; set; }
    }
}
