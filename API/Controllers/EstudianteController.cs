using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EstudianteController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public EstudianteController(IUserService userService)
        {
            _userService = userService;
        }



         [HttpPost]
         [ProducesResponseType(StatusCodes.Status201Created)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         public async Task<ActionResult<Estudiante>> Post(AddEstudianteDto EstudianteDto)
         {
            var Estudiante = mapper.Map<Estudiante>(EstudianteDto);
             unitofwork.Estudiantes.Add(Estudiante);
            await unitofwork.SaveAsync();
        
            if (Estudiante == null){
                return BadRequest();
            }
            EstudianteDto.Id = Estudiante.Id;
            return CreatedAtAction(nameof(Post), new {id = EstudianteDto.Id}, EstudianteDto); 
         }

 


        

        

    }
}