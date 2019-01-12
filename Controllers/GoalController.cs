using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using teamWcrh.Controllers.Resources.Goal;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
    public class GoalController : Controller
    {
        private IConfiguration _config;
        private readonly teamWCRHDbContext context;
        private readonly IMapper mapper;
        
        public GoalController(IConfiguration config,teamWCRHDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            _config = config;
        }

          [HttpPost]
        public async Task<IActionResult> CreateFeed([FromBody]GoalResource goal)
        {
            // Model Validation For DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Businness Logic Validation
            // if(true) {
            //     ModelState.AddModelError("..","error");
            //     return BadRequest(ModelState);
            // }

            
            return Ok();
        }

    }
}