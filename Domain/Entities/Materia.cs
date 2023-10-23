using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Materia : BaseEntity
    {
        public string NombreMateria {get; set;}
        public ICollection<GrupoMateria> GrupoMaterias {get; set;}
        public ICollection<MateriaProfesor> MateriaProfesores {get; set;}
        public ICollection<Grupo> Grupos { get; set; } = new HashSet<Grupo>();
        public ICollection<Profesor> Profesores { get; set; } = new HashSet<Profesor>();
        public ICollection<Corte> Cortes {get; set;}
    }
}