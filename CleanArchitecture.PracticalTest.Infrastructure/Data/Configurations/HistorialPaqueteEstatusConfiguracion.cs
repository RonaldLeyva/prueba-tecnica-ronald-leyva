using CleanArchitecture.PracticalTest.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Infrastructure.Data.Configurations
{
    public class HistorialPaqueteEstatusConfiguracion : BaseConfiguration<HistorialPaqueteEstatus>
    {
        public override void Configure(EntityTypeBuilder<HistorialPaqueteEstatus> builder)
        {
            builder.ToTable("historial_paquete_estatus");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Estatus)
                .IsRequired();

            builder.Property(x => x.FechaDeCambioEstado)
                .IsRequired();

            builder.Property(x => x.Motivo)
                .HasMaxLength(500); 
        }
    }
}
