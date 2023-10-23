using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Corte : BaseEntity
    {
        public double Actitudinal {get; set;}
        public double Evaluaciones {get; set;}
        public double Talleres {get; set;}
        public double Tareas {get; set;}
        public double AutoEvaluacion {get; set;}
        public int IdMateriaFK {get; set;}
        public Materia Materia {get; set;}
        public int IdBoletinFK {get; set;}
        public Boletin Boletin {get; set;}
        public int IdProfesorFK {get; set;}
        public Profesor Profesor {get; set;}
        public ICollection<Nota> Notas {get; set;}
    }
}