using Microsoft.EntityFrameworkCore;
using SistemaUsuarios.Models.Entities;

namespace SistemaUsuarios.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.CorreoElectronicoPrincipal)
                .IsUnique();
        }
    }
}