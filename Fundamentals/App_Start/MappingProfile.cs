using AutoMapper;
using Fundamentals.DomainModel;
using Fundamentals.Models.DTO;

namespace Fundamentals
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