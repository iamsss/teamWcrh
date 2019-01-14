using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using teamWcrh.Controllers.Resources.Goal;
using teamWcrh.Models;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> CreateGoal([FromBody]GoalResource goal)
        {
            // Model Validation For DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Businness Logic Validation
            // if(true) {
            //     ModelState.AddModelError("..","error");
            //     return BadRequest(ModelState);
            // }
            
            var realGoal = mapper.Map<GoalResource, Goal>(goal);
            realGoal.CreatedOn = DateTime.Now;
            await context.Goals.AddAsync(realGoal);
            await context.SaveChangesAsync();
            return Ok(realGoal);
        }

        [HttpPut]
        public async Task<IActionResult> GetGoalRequest([FromBody]GetGoalRequestResource data)
        {
            // Model Validation For DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Businness Logic Validation
            // if(true) {
            //     ModelState.AddModelError("..","error");
            //     return BadRequest(ModelState);
            // }
            string idsearch = data.UserId + "#";
            var goalRequests = await context.Goals.Where(
                goal => ((goal.GoalType == "All")
                || ( goal.GoalType == "Project Specific" && data.ProjectId.Contains(goal.ProjectId.Value)) 
                || (goal.GoalFor.Contains(idsearch) == true) 
                ) && (goal.GoalJoinedBy.Contains(idsearch) == false)
                ).ToListAsync();
            return Ok(goalRequests);
        }

        [HttpPut("/GoalAccept")]
        public async Task<IActionResult> Accept([FromBody]UserGoalIdResource data)
        {
            // Model Validation For DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Businness Logic Validation
            // if(true) {
            //     ModelState.AddModelError("..","error");
            //     return BadRequest(ModelState);
            // }

            string idsearch = data.UserId + "#";
            var goal = await context.Goals.FindAsync(data.GoalId);
            if(goal.GoalFor.Contains(idsearch) == true){
                goal.GoalFor.Replace(idsearch, "");
            }
            goal.GoalJoinedBy += idsearch;

            var userGoal = new UserGoal{
                JoinedOn = DateTime.Now,
                Status = "pending",
                UserId = data.UserId 
            };
            goal.Users.Add(userGoal);
            await context.SaveChangesAsync();
            return Ok("Success");
        }
        [HttpPut("/GoalReject")]
        public async Task<IActionResult> Reject([FromBody]UserGoalIdResource data)
        {
            // Model Validation For DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Businness Logic Validation
            // if(true) {
            //     ModelState.AddModelError("..","error");
            //     return BadRequest(ModelState);
            // }

            string idsearch = data.UserId + "#";
            var goal = await context.Goals.FindAsync(data.GoalId);
            goal.GoalRejectedBy += idsearch;
            await context.SaveChangesAsync();
            return Ok("Success");
        }

        [HttpPut("/ChangeGoalStatus")]
        public async Task<IActionResult> ChangeGoalStatus([FromBody]ChangeGoalStatusResource data)
        {
            // Model Validation For DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Businness Logic Validation
            // if(true) {
            //     ModelState.AddModelError("..","error");
            //     return BadRequest(ModelState);
            // }

            var userGoal = await context.UserGoal.Where(ug => ug.GoalId == data.GoalId && ug.UserId == data.UserId).FirstOrDefaultAsync();
            userGoal.Status = data.Status;
            await context.SaveChangesAsync();
            return Ok("success");
        }

    }
}