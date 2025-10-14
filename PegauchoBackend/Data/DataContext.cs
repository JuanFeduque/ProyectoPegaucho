using Microsoft.EntityFrameworkCore;
using Orders.Shared.Entities;
using Pegaucho.Shared.Entities;

namespace PegauchoBackend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<PanelControl> PanelesControl { get; set; } = null!;
    public DbSet<OrdenProduccion> OrdenesProduccion { get; set; } = null!;
    public DbSet<OrdenDosificacion> OrdenesDosificacion { get; set; } = null!;
    //validaciones
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Usuario>().HasIndex(x => x.usuario).IsUnique();
        modelBuilder.Entity<PanelControl>().HasIndex(x => x.IdOrdenPanel).IsUnique();
        modelBuilder.Entity<OrdenProduccion>().HasIndex(x => x.IdOrdenProd).IsUnique();
        modelBuilder.Entity<OrdenDosificacion>().HasIndex(x => x.IdOrdenDos).IsUnique();
        modelBuilder.Entity<PanelControl>()
            .HasOne(p => p.Usuario)
            .WithMany(u => u.Paneles)
            .HasForeignKey(p => p.IdLogin)
            .OnDelete(DeleteBehavior.Restrict); // ⚠️ NO CASCADE - Evita ciclo

        // Relación: Usuario -> OrdenProduccion (1:N)
        modelBuilder.Entity<OrdenProduccion>()
            .HasOne(op => op.Usuario)
            .WithMany(u => u.OrdenesProducciones)
            .HasForeignKey(op => op.IdLogin)
            .OnDelete(DeleteBehavior.Restrict); // ⚠️ NO CASCADE - Evita ciclo

        // Relación: PanelControl -> OrdenProduccion (1:N)
        modelBuilder.Entity<OrdenProduccion>()
            .HasOne(op => op.PanelControl)
            .WithMany(p => p.OrdenesProduccion)
            .HasForeignKey(op => op.IdOrdenPanel)
            .OnDelete(DeleteBehavior.Cascade); // ✅ CASCADE permitido

        // Relación: PanelControl -> OrdenDosificacion (1:N)
        modelBuilder.Entity<OrdenDosificacion>()
            .HasOne(od => od.PanelControl)
            .WithMany(p => p.OrdenesDosificaciones)
            .HasForeignKey(od => od.IdOrdenPanel)
            .OnDelete(DeleteBehavior.Restrict); // ⚠️ NO CASCADE - Evita ciclo

        // Relación: OrdenProduccion -> OrdenDosificacion (1:N)
        modelBuilder.Entity<OrdenDosificacion>()
            .HasOne(od => od.OrdenProduccion)
            .WithMany(op => op.OrdenesDosificaciones)
            .HasForeignKey(od => od.IdOrdenProd)
            .OnDelete(DeleteBehavior.Cascade);
    }   
}
