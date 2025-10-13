using Microsoft.EntityFrameworkCore;
using Orders.Shared.Entities;

namespace PegauchoBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        //validaciones
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().HasIndex(x => x.usuario).IsUnique();
        }   */
    }

}
