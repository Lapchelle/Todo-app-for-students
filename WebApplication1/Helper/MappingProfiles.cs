using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<WebApplication1.Models.Task, TaskDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Status, StatusDto>();
            CreateMap<StatusDto, Status>();
            CreateMap<Target, TargetDto>();
            CreateMap<TaskDto, WebApplication1.Models.Task>();
            CreateMap<TargetDto, Target>();
            CreateMap<ContactDto, Contact>();
           
        }
    }
}
