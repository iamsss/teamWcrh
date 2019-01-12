using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
    public class EventController : Controller
    {
        private IConfiguration _config;
        private readonly teamWCRHDbContext context;
        private readonly IMapper mapper;
        
        public EventController(IConfiguration config,teamWCRHDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            _config = config;
        }
    }
}