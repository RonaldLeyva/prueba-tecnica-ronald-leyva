using Microsoft.EntityFrameworkCore;
using CleanArchitecture.PracticalTest.Domain.Common;
using CleanArchitecture.PracticalTest.Domain.Entidades;
using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;

namespace CleanArchitecture.PracticalTest.Infrastructure.Data;

public class ContextDb : DbContext, IContextDb
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
    }
    public DbSet<Paquete> Paquetes { get; set; }    
    public DbSet<HistorialPaqueteEstatus> HistorialPaqueteEstatus { get; set; }
    public DbSet<Ruta> Rutas { get; set; }

    public async Task AddAsync(Paquete paquete)
    {
        await Paquetes.AddAsync(paquete);
        await SaveChangesAsync();
    }

    public async Task<Paquete?> GetByIdAsync(Guid id)
    {
        return await Paquetes.Include(x => x.Ruta).FirstOrDefaultAsync(y => y.Id == id);
    }

    public IQueryable<Paquete> PaquetesQuery()
    {
        return this.Paquetes
            .Include(x => x.Ruta)
            .Include(x => x.Historial)
            .AsQueryable();
    }

    // Sobreescribir el metodo SaveChangesAsync para que se actualicen las propiedades de auditoria
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = !entry.Entity.UpdatedBy.HasValue ?
                        Guid.Empty : entry.Entity.UpdatedBy;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Paquete paquete)
    {
        if (paquete.Ruta != null && Entry(paquete.Ruta).State == EntityState.Detached)
        {
            Rutas.Add(paquete.Ruta);
        }

        foreach (var historial in paquete.Historial)
        {
            if (Entry(historial).State == EntityState.Detached)
                Entry(historial).State = EntityState.Added;
        }

        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aqui se agregan las configuraciones de las entidades para ser mapeadas a la base de datos
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextDb).Assembly);
    }
}