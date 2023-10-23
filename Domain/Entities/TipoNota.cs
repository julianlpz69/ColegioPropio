using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoNota : BaseEntity
    {
        public string NombreTipo {get; set;}
        public double ValorPorcentaje {get; set;}
        public ICollection<Nota> Notas {get; set;}
    }
}