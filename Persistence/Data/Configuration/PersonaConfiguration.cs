using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder){
    
            builder.ToTable("persona");

            builder.Property(u => u.Nombres).HasMaxLength(255);

            builder.HasOne(p => p.TipoDocumento)
                .WithMany(p => p.Personas)
                .HasForeignKey(p => p.IdTipoDocumentoFK);


            builder.HasOne(p => p.Estudiante)
                .WithOne(p => p.Persona)
                 .HasForeignKey<Estudiante>(d => d.Id);
        }
    }
}