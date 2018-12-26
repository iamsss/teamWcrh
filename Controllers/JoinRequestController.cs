using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using teamWcrh.Models;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
    [Route("api/[controller]")]
    public class JoinRequestController : Controller
    {
        
        private readonly teamWCRHDbContext context;
        public JoinRequestController(teamWCRHDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public List<JoinRequest> GetAll()
        {
            return context.JoinRequests.ToList();
        }
    }
}