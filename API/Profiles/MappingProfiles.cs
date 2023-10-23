using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
         public MappingProfiles()
        {

            CreateMap<Estudiante, AddEstudianteDto>().ReverseMap();

            CreateMap<Persona, AddPersonaDto>().ReverseMap();

            CreateMap<Direccion, AddDireccionDto>().ReverseMap();

            CreateMap<Usuario, AddUsuarioDto>().ReverseMap();


        }
    }
}