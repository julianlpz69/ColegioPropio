using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PadreConfiguration : IEntityTypeConfiguration<Padre>
    {
        public void Configure(EntityTypeBuilder<Padre> builder){
    
            builder.ToTable("padre");
    
            
            builder.HasOne(p => p.Estudiante)
                .WithMany(p => p.Padres)
                .HasForeignKey(p => p.IdEstudianteFK);

            builder.HasOne(p => p.Persona)
                .WithOne(p => p.Padre)
                 .HasForeignKey<Padre>(d => d.Id);

        }
    }
}