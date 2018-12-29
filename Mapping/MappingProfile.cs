using AutoMapper;
using teamWcrh.Controllers.Resources;
using teamWcrh.Models;

namespace teamWcrh.Mapping
{
    public class MappingProfile : Profile
    {
         public MappingProfile() {
            CreateMap<User, UserResource>();
            CreateMap<JoinRequest, JoinRequestResource>();
            CreateMap<JoinRequestResource, JoinRequest>();
        }
    }
}