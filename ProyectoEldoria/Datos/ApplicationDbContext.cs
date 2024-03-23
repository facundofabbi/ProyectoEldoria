using Microsoft.EntityFrameworkCore;
using ProyectoEldoria.Models;

namespace ProyectoEldoria.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }

        //Aca van los modelos
        public DbSet<Aventurero> Aventurero { get; set; }

        public DbSet<Mentor> Mentor { get; set; }
    }
}
