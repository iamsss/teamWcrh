using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teamWcrh.Controllers.Resources;
using teamWcrh.Models;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
    [Route("api/[controller]")]
    public class JoinRequestController : Controller
    {

        private readonly teamWCRHDbContext context;
        private readonly IMapper mapper;

        public JoinRequestController(teamWCRHDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<JoinRequestResource>> GetFeatures()
        {
            var features = await context.JoinRequests.ToListAsync();

            return mapper.Map<List<JoinRequest>, List<JoinRequestResource>>(features);

        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] JoinRequestResource jrData)
        {
            // Model Validation For DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Businness Logic Validation
            // if(true) {
            //     ModelState.AddModelError("..","error");
            //     return BadRequest(ModelState);
            // }
            var joinRequest = mapper.Map<JoinRequestResource, JoinRequest>(jrData);

            joinRequest.LastUpdate = DateTime.Now;
            joinRequest.CreatedOn = DateTime.Now;

            await context.JoinRequests.AddAsync(joinRequest);
            await context.SaveChangesAsync();
            return Ok(joinRequest);
        }

    }
}