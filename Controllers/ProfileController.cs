using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using teamWcrh.Controllers.Resources;
using teamWcrh.Controllers.Resources.Goal;
using teamWcrh.Controllers.Resources.User;
using teamWcrh.Models;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
   
    
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

       [Route("api/[controller]")] 
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
        [HttpGet("api/[controller]/{id}")]
        public async Task<IActionResult> GetUser(int id){
            var ua =  await context.Users.
            Include(u => u.UserProjects)
            .Include(u => u.Goals).Where(user => user.UserId == id).FirstOrDefaultAsync();
             
             var tem = mapper.Map<User, ProfileResource>(ua);

            // Mapping Of Projects to ProjectUser
             foreach(var project in ua.UserProjects){
                 var pro = await context.Projects.FindAsync(project.ProjectId);
                    var temp = new KeyValueResource {
                        Id = project.ProjectId,
                        Name = pro.Name
                    };
                    tem.Projects.Add(temp);
             }

             // Empty the temp.Goals
             var goals = ua.Goals;
             ICollection<GoalUserResource> go = new Collection<GoalUserResource>();
             tem.Goals = go; 

            // mapping of goal to GoalUserResources
             foreach(var goal in goals){
                 var tempGoal = await context.Goals.FindAsync(goal.GoalId);
                 var userGoal = mapper.Map<UserGoal,GoalUserResource>(goal);
                 var finalUserGoal = mapper.Map<Goal,GoalUserResource>(tempGoal,userGoal);
                 tem.Goals.Add(userGoal);
             }
           return Ok(tem);

           // var principal = HttpContext.User;
           // var data = principal?.Claims?.SingleOrDefault(p => p.Type == "UserId")?.Value;
           // return Ok(data);
        
        }
        [Route("api/[controller]")]
        [HttpPut("{id}")]
        public async Task<IActionResult> RemoveProject(int id, [FromBody] int projectId)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           var user = await context.Users.Include(u => u.UserProjects).Where(u => u.UserId == id).FirstOrDefaultAsync();  
            
            var up = new UserProject();
            foreach(var project in user.UserProjects){
                if(project.ProjectId == projectId){
                   up = project;
                }
            }
            user.UserProjects.Remove(up);

            await context.SaveChangesAsync();
            return Ok("success");
        }


       
        

    }
}