using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Boletin : BaseEntity
    {
        public int Periodo {get; set;}
        public int IdEstudianteFK {get; set;}
        public Estudiante Estudiante {get; set;}
        public ICollection<Corte> Cortes {get; set;}
        
    }
}