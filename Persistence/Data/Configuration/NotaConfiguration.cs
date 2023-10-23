using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class NotaConfiguration : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder){
    
            builder.ToTable("nota");
    
            
            builder.HasOne(p => p.TipoNota)
                .WithMany(p => p.Notas)
                .HasForeignKey(p => p.IdTipoNotaFK);

        

        }
    }
}