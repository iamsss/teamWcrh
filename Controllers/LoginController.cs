using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using teamWcrh.Controllers.Resources;
using teamWcrh.Controllers.Resources.Goal;
using teamWcrh.Controllers.Resources.User;
using teamWcrh.Models;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
         private IConfiguration _config;
         private readonly teamWCRHDbContext context;
          private readonly IMapper mapper;
        public LoginController(IConfiguration config,teamWCRHDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody]LoginResource login)
        {
            // Model Validation For DataAnnotations
            if(!ModelState.IsValid)
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IActionResult response = Unauthorized();
            AuthenticateResource ar =  await Authenticate(login);

            return  Ok(ar);
        }

        private string BuildToken(ProfileResource user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] {  
                new Claim(ClaimTypes.Role, user.UserRole),   
                new Claim("UserId", Convert.ToString(user.UserId))
    };  

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(3000),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<AuthenticateResource> Authenticate(LoginResource login)
        {
            var user = await context.Users.
            Include(u => u.UserProjects)
            .Include(u => u.Goals).Where(ur => ur.UserId == login.UserId).FirstOrDefaultAsync();

            AuthenticateResource ar = new AuthenticateResource{ 
                Status = false,
                Token = "",
                ErrorMessage = "",
                UserResource = null
            };

            if(user != null){
                if(user.Password == login.Password){
                    ar.Status = true;
                    ar.UserResource = mapper.Map<User, ProfileResource>(user);

                     // Mapping Of Projects to ProjectUser
             foreach(var project in user.UserProjects){
                 var pro = await context.Projects.FindAsync(project.ProjectId);
                    var temp = new KeyValueResource {
                        Id = project.ProjectId,
                        Name = pro.Name
                    };
                   ar.UserResource.Projects.Add(temp);
             }

             // Empty the temp.Goals
             var goals = user.Goals;
             ICollection<GoalUserResource> go = new Collection<GoalUserResource>();
            ar.UserResource.Goals = go; 

            // mapping of goal to GoalUserResources
             foreach(var goal in goals){
                 var tempGoal = await context.Goals.FindAsync(goal.GoalId);
                 var userGoal = mapper.Map<UserGoal,GoalUserResource>(goal);
                 var finalUserGoal = mapper.Map<Goal,GoalUserResource>(tempGoal,userGoal);
                ar.UserResource.Goals.Add(userGoal);
             }

                    ar.Token = BuildToken(ar.UserResource);
                }else{
                    ar.ErrorMessage = "Your password is incorrect";
                }
            }else{
                ar.ErrorMessage = "Your UserId is not valid";
            }
            return ar;     
        }


       
    }
    
    }
