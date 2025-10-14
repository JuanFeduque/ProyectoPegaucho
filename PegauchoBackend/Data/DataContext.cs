using Microsoft.EntityFrameworkCore;
using Orders.Shared.Entities;
using Pegaucho.Shared.Entities;

namespace PegauchoBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produccion> Producciones { get; set; }
        //validaciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasIndex(x => x.usuario).IsUnique();
            modelBuilder.Entity<Produccion>().HasIndex(x => x.idOrdenProd).IsUnique();
        }   
    }

}
