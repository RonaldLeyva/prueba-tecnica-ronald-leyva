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
    public  class PaqueteConfiguracion: BaseConfiguration<Paquete>
    {
        public override void Configure(EntityTypeBuilder<Paquete> builder)
        {
            base.Configure(builder);

            builder.ToTable("paquetes");

            builder.Property(x => x.Peso)
                .IsRequired();

            builder.Property(x => x.Longitud)
                .IsRequired();

            builder.Property(x => x.Ancho)
                .IsRequired();

            builder.Property(x => x.Altura)
                .IsRequired();

            builder.Property(x => x.Estatus)
                .IsRequired();

            builder.HasOne(x => x.Ruta)
            .WithMany()
            .HasForeignKey(x => x.RutaId);

        builder.HasMany(x => x.Historial)
            .WithOne()
            .HasForeignKey(x => x.PaqueteId);
        }
    }
}
