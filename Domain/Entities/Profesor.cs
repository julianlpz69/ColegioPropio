using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Profesor : BaseEntity
    {
        public byte[] Titulacion {get; set;}
        public string Especialidad {get; set;}
        public Persona Persona {get; set;}
        public ICollection<GrupoProfesor> GrupoProfesores {get; set;}
        public ICollection<Grupo> Grupos { get; set; } = new HashSet<Grupo>();
        public ICollection<MateriaProfesor> MateriaProfesores {get; set;}
        public ICollection<Materia> Materias { get; set; } = new HashSet<Materia>();
        public ICollection<Corte> Cortes {get; set;}
    }
}