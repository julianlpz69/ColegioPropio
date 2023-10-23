using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MateriaProfesor
    {
        public int IdMateriaFK {get; set;}
        public Materia Materia {get; set;}
        public int IdProfesorFK {get; set;}
        public Profesor Profesor {get; set;}
    }
}