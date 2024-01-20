using Microsoft.EntityFrameworkCore;

namespace BE_altaEmpleados.Models
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Empleado> datosEmpleado { get; set; }
        public DbSet<Cargo> cargo { get; set; }
    }
}
