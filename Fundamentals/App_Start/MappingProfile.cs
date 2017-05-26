using AutoMapper;
using Fundamentals.DomainModel;
using Fundamentals.Models.Admin;
using Fundamentals.Models.Authorization;
using Fundamentals.Models.DTO;
using Fundamentals.Utility;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fundamentals
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            Mapper.CreateMap<MovieViewModel, MovieDto>();

            Mapper.CreateMap<MovieDto, MovieViewModel>();

            Mapper.CreateMap<Ganres, GanreDto>();

            Mapper.CreateMap<ApplicationUser, AspNetUserDto>();

            Mapper.CreateMap<IdentityRole, AspNetRoleDto>();

            Mapper.CreateMap<UserInRolesDto, UserInRolesViewModel>();

            Mapper.CreateMap<IdentityRole, UserInRolesViewModel>();

        }
    }
}