using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Estudiante :BaseEntity
    {
        public int IdGrupoFK {get; set;}
        public Grupo Grupo {get; set;}
        public Persona Persona {get; set;}
        public ICollection<Boletin> Boletines {get; set;}
        public ICollection<Padre> Padres {get; set;}
        public ICollection<Matricula> Matriculas {get; set;}
    }
}