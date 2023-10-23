using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Services
{
    public interface IUserService
    {
         Task<string> RegisterAsync(RegistrarDto model);
        Task<DatosUsuarioDto> GetTokenAsync(LogiarDto model);
        Task<DatosUsuarioDto> RefreshTokenAsync(string refreshToken);
    }
}