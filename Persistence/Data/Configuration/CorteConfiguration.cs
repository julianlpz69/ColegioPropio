using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CorteConfiguration : IEntityTypeConfiguration<Corte>
    {
        public void Configure(EntityTypeBuilder<Corte> builder){
    
            builder.ToTable("corte");
        
            builder.Property(e => e.Actitudinal).HasMaxLength(5);
            
            

            builder.HasOne(p => p.Materia)
                .WithMany(p => p.Cortes)
                .HasForeignKey(p => p.IdMateriaFK);

            builder.HasOne(p => p.Profesor)
                .WithMany(p => p.Cortes)
                .HasForeignKey(p => p.IdProfesorFK);

            builder.HasOne(p => p.Boletin)
                .WithMany(p => p.Cortes)
                .HasForeignKey(p => p.IdBoletinFK);

            
    
        }
    }
} 