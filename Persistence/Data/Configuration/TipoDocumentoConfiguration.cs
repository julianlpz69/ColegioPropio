using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TipoDocumentoConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> builder){
    
            builder.ToTable("tipo_documento");

            builder.Property(u => u.NombreTipo).HasMaxLength(100);

            builder.HasData(
                new TipoDocumento {Id= 1, NombreTipo = "Cedula de Ciudadania"},
                new TipoDocumento {Id= 2, NombreTipo = "Tarjeta de Identidad"},
                new TipoDocumento {Id= 3, NombreTipo = "Cédula de Extranjería"},
                new TipoDocumento {Id= 4, NombreTipo = "Pasaporte"},
                new TipoDocumento {Id= 5, NombreTipo = "Permiso Especial de Permanencia (PEP)"},
                new TipoDocumento {Id= 6, NombreTipo = "Permiso de Proteccion Temporak (PPT)"}
            );

        }
    }
}