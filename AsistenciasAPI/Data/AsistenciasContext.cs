using Microsoft.EntityFrameworkCore;

namespace AsistenciasAPI.Models
{
    public class AsistenciasContext : DbContext
    {
        public AsistenciasContext(DbContextOptions<AsistenciasContext> options) : base(options) { }

        public DbSet<Asistencia> Asistencias { get; set; }
    }
}
