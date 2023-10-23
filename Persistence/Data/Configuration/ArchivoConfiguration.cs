using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ArchivoConfiguration : IEntityTypeConfiguration<Archivo>
    {
        public void Configure(EntityTypeBuilder<Archivo> builder){
    
            builder.ToTable("archivo");

            builder.Property(u => u.Ruta).HasMaxLength(255);

           
            builder.HasOne(p => p.Persona)
                .WithMany(p => p.Archivos)
                .HasForeignKey(p => p.IdPersonaFK);
        }
    }
}