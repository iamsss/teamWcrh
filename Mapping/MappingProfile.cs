using System.Linq;
using AutoMapper;
using teamWcrh.Controllers.Resources;
using teamWcrh.Controllers.Resources.Feed;
using teamWcrh.Controllers.Resources.Project;
using teamWcrh.Controllers.Resources.User;
using teamWcrh.Models;

namespace teamWcrh.Mapping
{
    public class MappingProfile : Profile
    {
         public MappingProfile() {
            CreateMap<User, UserResource>();
            CreateMap<JoinRequest, JoinRequestResource>();
            CreateMap<JoinRequestResource, JoinRequest>();
            CreateMap<ProjectResource, Project>();
            CreateMap<FeedResource, Feed>();
            CreateMap<Feed, FeedResource>();
            CreateMap<User, ProfileResource>();
            
       }
    }
}