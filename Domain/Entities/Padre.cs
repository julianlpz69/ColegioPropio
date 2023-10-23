using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Padre : BaseEntity
    {
        public int IdEstudianteFK {get; set;}
        public Estudiante Estudiante {get; set;}
        public Persona Persona {get; set;}
    }
}