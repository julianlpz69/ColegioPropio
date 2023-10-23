using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class BoletinConfiguration : IEntityTypeConfiguration<Boletin>
    {
        public void Configure(EntityTypeBuilder<Boletin> builder){
    
            builder.ToTable("boletin");
    
            builder.Property(e => e.Periodo)
                .HasMaxLength(4);

            builder.HasOne(p => p.Estudiante)
                .WithMany(p => p.Boletines)
                .HasForeignKey(p => p.IdEstudianteFK);
        }
    }
}