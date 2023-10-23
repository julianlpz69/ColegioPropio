using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Grupo : BaseEntity
    {
        public string NombreGrupo {get; set;}
        public int IdGradoFK {get; set;}
        public Grado Grado {get; set;}
        public ICollection<GrupoMateria> GrupoMaterias {get; set;}
        public ICollection<GrupoProfesor> GrupoProfesores {get; set;}
        public ICollection<Estudiante> Estudiantes {get; set;}

        public ICollection<Materia> Materias { get; set; } = new HashSet<Materia>();
        public ICollection<Profesor> Profesores { get; set; } = new HashSet<Profesor>();
    }
}