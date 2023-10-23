using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;

    public class UnitOfWork : IUnitOfWork
    {

        private readonly ColegioDBContext _context; 
        
        private IRol _roles;
        private IUsuario _usuario;
        private IEstudiante _estudiante;


        public UnitOfWork(ColegioDBContext context){
            _context = context;
        }

    
        
        public IRol Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }


        public IUsuario Usuarios
        {
            get
            {
                if (_usuario == null)
                {
                    _usuario = new UsuarioRepository(_context);
                }
                return _usuario;
            }
        }



        public IEstudiante Estudiantes
        {
            get
            {
                if (_estudiante == null)
                {
                    _estudiante = new EstudianteRepository(_context);
                }
                return _estudiante;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }