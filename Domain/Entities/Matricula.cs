using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Matricula : BaseEntity
    {
        public byte[] Contenido { get; set; }
        public int IdEstudianteFK {get; set;}
        public Estudiante Estudiante {get; set;}
    }
}