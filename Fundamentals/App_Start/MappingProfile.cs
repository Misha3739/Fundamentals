using AutoMapper;
using Fundamentals.DomainModel;
using Fundamentals.Models.Authorization;
using Fundamentals.Models.DTO;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fundamentals
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            Mapper.CreateMap<MovieViewModel, MovieDTO>();

            Mapper.CreateMap<MovieDTO, MovieViewModel>();

            Mapper.CreateMap<Ganres, GanreDTO>();

            Mapper.CreateMap<ApplicationUser, AspNerUserDTO>();
        }
    }
}