
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using teamWcrh.Controllers.Resources.Project;
using teamWcrh.Models;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
    public class ProjectController : Controller
    {
        
        private IConfiguration _config;
        private readonly teamWCRHDbContext context;
        private readonly IMapper mapper;
        
        public ProjectController(IConfiguration config,teamWCRHDbContext context,IMapper mapper)
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
         [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody]ProjectResource projectData)
        {
            // Model Validation For DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var project = mapper.Map<ProjectResource, Project>(projectData);
 

            await context.Projects.AddAsync(project);
            await context.SaveChangesAsync();
            return Ok(project);

        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetAllProject(){
            var projects =  await context.Projects.ToListAsync();
            
            return Ok(projects);
        }

        [Route("api/[controller]")]
        [HttpGet("{id}")]
         public async Task<IActionResult> GetProject(int id){
            var project =  await context.Projects.FindAsync(id);
            return Ok(project);
        } 

         [Route("api/link/[controller]")]
         [HttpPost]
        public async Task<IActionResult> LinkProjectUser([FromBody]LinkProjectUserResource data)
        {
            // Model Validation For DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await context.Users.FindAsync(data.UserId);
            var project = await context.Projects.FindAsync(data.ProjectId);
            var ur = new UserProject{
                User=user,
                UserId = user.UserId,
                Project= project,
                ProjectId = project.ProjectId
            };
            await context.UserProjects.AddAsync(ur);
             user.UserProjects.Add(ur);
            await context.SaveChangesAsync();
            return Ok("success");
        }

        
    }
}