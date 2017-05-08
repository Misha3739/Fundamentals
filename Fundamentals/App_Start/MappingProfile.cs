using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Fundamentals.Models.DTO;
using Fundamentals.Models.Movies;

namespace Fundamentals.App_Start
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            Mapper.CreateMap<MovieViewModel, MovieDTO>();

            Mapper.CreateMap<MovieDTO, MovieViewModel>();

            Mapper.CreateMap<Ganres, GanreDTO>();
        }
    }
}