using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
        IRol Roles { get; }
        IUsuario Usuarios { get; }
        IEstudiante Estudiantes { get; }

    }
}