using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using teamWcrh.Controllers.Resources.User;
using teamWcrh.Models;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
       
       
        private IConfiguration _config;
        private readonly teamWCRHDbContext context;
        private readonly IMapper mapper;
        
        public ProfileController(IConfiguration config,teamWCRHDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        
       [HttpGet]
        public async Task<IActionResult> GetAllUser(){
            var ua =  await context.Users.Include(u => u.UserProjects).ToListAsync();
            IList<ProfileResource> tempua = new  List<ProfileResource>();
           foreach (User u in ua){
               var tem = mapper.Map<User, ProfileResource>(u);
               tempua.Add(tem);
           }
           return Ok(tempua);
        }
        
        


       
        

    }
}