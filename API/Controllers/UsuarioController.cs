using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsuarioController : BaseApiController
    {
        private readonly IUserService _userService;

        public UsuarioController(IUserService userService)
        {
            _userService = userService;
        }


 


        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegistrarDto model)
        {
            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        } 

      
        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(LogiarDto model)
        {
            var result = await _userService.GetTokenAsync(model);
            SetRefreshTokenInCookie(result.RefreshToken);
            return Ok(result);
        }


        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _userService.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(response.RefreshToken))
                SetRefreshTokenInCookie(response.RefreshToken);
            return Ok(response);
        }


        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(10),
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }


        

    }
}