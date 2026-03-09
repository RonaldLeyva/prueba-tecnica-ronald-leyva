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
    public class RutaConfiguracion : BaseConfiguration<Ruta>
    {
        public override void Configure(EntityTypeBuilder<Ruta> builder)
        {
            builder.ToTable("rutas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Origen)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Destino)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.DistanciaEnKm)
                .IsRequired();

            builder.Property(x => x.HorasEstimadas)
                .IsRequired();
        }
    }
}
