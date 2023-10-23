using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly JWT _jwt;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<Usuario> _passwordHasher;
        
        public UserService(IUnitOfWork unitOfWork, IOptions<JWT> jwt, IPasswordHasher<Usuario> passwordHasher)
        {
            _jwt = jwt.Value;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }


        public async Task<string> RegisterAsync(RegistrarDto registerDto)
        {
            var user = new Usuario
            {
                CorreoUsuario = registerDto.CorreoUsuario,
            };

            user.ClaveUsuario = _passwordHasher.HashPassword(user, registerDto.ClaveUsuario); //Encrypt password

            var existingUser = _unitOfWork.Usuarios
                                        .Find(u => u.CorreoUsuario.ToLower() == registerDto.CorreoUsuario.ToLower())
                                        .FirstOrDefault();


            if (existingUser == null)
            {
                var rolExists = _unitOfWork.Roles
                                            .Find(u => u.NombreRol.ToLower() == registerDto.RolUsuario.ToLower())
                                            .FirstOrDefault();

                if (rolExists != null){

                    try
                {
                    user.IdRolFK = rolExists.Id;
                    _unitOfWork.Usuarios.Add(user);
                    await _unitOfWork.SaveAsync();

                    return $"Usuario Registrado Correctamente";
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                    return $"Error: {message} " ;
                }
                }

                else{
                    return $"El Rol No Existe";
                }
                
            }
            else
            {
                return $"Usuario ya tiene Registro";
            }
        }







        public async Task<DatosUsuarioDto> GetTokenAsync(LogiarDto model)
        {
            DatosUsuarioDto dataUserDto = new DatosUsuarioDto();
            var user = await _unitOfWork.Usuarios
                        .GetByUserGmailAsync(model.CorreoUsuario);

            if (user == null)
            {
                dataUserDto.RefreshToken = "";
                dataUserDto.RefreshTokenExpiry = DateTime.Now;
                dataUserDto.UsuarioToken = "";
                dataUserDto.CorreoUsuario = "";
                dataUserDto.UsuarioRol = null;
                dataUserDto.EstadoAutenticado = false;
                dataUserDto.Mensaje = $"Correo Electronico No Existente en la base de datos";
                return dataUserDto;
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.ClaveUsuario, model.ClaveUsuario);

            if (result == PasswordVerificationResult.Success)
            {
                dataUserDto.EstadoAutenticado = true;
                JwtSecurityToken jwtSecurityToken = CreateJwtToken(user);
                dataUserDto.UsuarioToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                dataUserDto.CorreoUsuario = user.CorreoUsuario;
                dataUserDto.UsuarioRol = user.Rol.NombreRol;
                                                
                                                

                if (user.RefreshTokens.Any(a => a.IsActive))
                {
                    var activeRefreshToken = user.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
                    dataUserDto.Mensaje = "Usuario Existente";
                    dataUserDto.RefreshToken = activeRefreshToken.Token;
                    dataUserDto.RefreshTokenExpiry = activeRefreshToken.Expires;
                }
                else
                {
                    var refreshToken = CreateRefreshToken();
                    dataUserDto.RefreshToken = refreshToken.Token;
                    dataUserDto.RefreshTokenExpiry = refreshToken.Expires;
                    user.RefreshTokens.Add(refreshToken);
                    _unitOfWork.Usuarios.Update(user);
                    await _unitOfWork.SaveAsync();
                }

                return dataUserDto;
            }

            dataUserDto.RefreshToken = "";
                dataUserDto.RefreshTokenExpiry = DateTime.Now;
                dataUserDto.UsuarioToken = "";
                dataUserDto.CorreoUsuario = "";
                dataUserDto.UsuarioRol = null;
            dataUserDto.EstadoAutenticado = false;
            dataUserDto.Mensaje = $"Contraseña incorrectas";
            return dataUserDto;
        }












        public async Task<DatosUsuarioDto> RefreshTokenAsync(string refreshToken)
        {
            var dataUserDto = new DatosUsuarioDto();

            var usuario = await _unitOfWork.Usuarios
                            .GetByRefreshTokenAsync(refreshToken);

            if (usuario == null)
            {
                dataUserDto.EstadoAutenticado = false;
                dataUserDto.Mensaje = $"Token is not assigned to any user.";
                return dataUserDto;
            }

            var refreshTokenBd = usuario.RefreshTokens.Single(x => x.Token == refreshToken);

            if (!refreshTokenBd.IsActive)
            {
                dataUserDto.EstadoAutenticado = false;
                dataUserDto.Mensaje = $"Token is not active.";
                return dataUserDto;
            }
            //Revoque the current refresh token and
            refreshTokenBd.Revoked = DateTime.UtcNow;
            //generate a new refresh token and save it in the database
            var newRefreshToken = CreateRefreshToken();
            usuario.RefreshTokens.Add(newRefreshToken);
            _unitOfWork.Usuarios.Update(usuario);
            await _unitOfWork.SaveAsync();
            //Generate a new Json Web Token
            dataUserDto.EstadoAutenticado = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
            dataUserDto.UsuarioToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            dataUserDto.CorreoUsuario = usuario.CorreoUsuario;
            dataUserDto.UsuarioRol = usuario.Rol.NombreRol;
            dataUserDto.RefreshToken = newRefreshToken.Token;
            dataUserDto.RefreshTokenExpiry = newRefreshToken.Expires;
            return dataUserDto;
        }














        private RefreshToken CreateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomNumber);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomNumber),
                    Expires = DateTime.UtcNow.AddDays(10),
                    Created = DateTime.UtcNow
                };
            }
        }







        private JwtSecurityToken CreateJwtToken(Usuario usuario)
        {
            var roles = usuario.Rol;
            var roleClaims = new List<Claim>();
            
                roleClaims.Add(new Claim("roles", roles.NombreRol));
            
            var claims = new[]
            {
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                    new Claim(JwtRegisteredClaimNames.Email, usuario.CorreoUsuario),
                                    new Claim("uid", usuario.Id.ToString())
                            }
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}