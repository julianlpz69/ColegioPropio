using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
    {
        private readonly ColegioDBContext _context;

        public UsuarioRepository(ColegioDBContext context):base(context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
        }

        public async Task<Usuario> GetByUserGmailAsync(string userEmail)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.CorreoUsuario.ToLower() == userEmail.ToLower());
        }
    }
}