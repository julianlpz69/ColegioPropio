using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsuario : IGenericRepository<Usuario>
    {
        Task<Usuario> GetByUserGmailAsync(string username);
        Task<Usuario> GetByRefreshTokenAsync(string username); 
    }
}