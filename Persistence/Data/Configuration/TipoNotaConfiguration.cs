using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TipoNotaConfiguration : IEntityTypeConfiguration<TipoNota>
    {
        public void Configure(EntityTypeBuilder<TipoNota> builder){
    
            builder.ToTable("tipo_nota");

            builder.HasData(
                new TipoNota {Id= 1, NombreTipo = "Actitudinal", ValorPorcentaje =10},
                new TipoNota {Id= 2, NombreTipo = "AutoEvaluacion", ValorPorcentaje =10},
                new TipoNota {Id= 3, NombreTipo = "Talleres", ValorPorcentaje =25},
                new TipoNota {Id= 4, NombreTipo = "Evaluaciones", ValorPorcentaje =35},
                new TipoNota {Id= 5, NombreTipo = "Tareas", ValorPorcentaje =20}
            );

        

        }
    }
}