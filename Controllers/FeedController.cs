using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using teamWcrh.Controllers.Resources.Feed;
using teamWcrh.Models;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
    [Route("api/[controller]")]
    public class FeedController : Controller
    {
        
        private IConfiguration _config;
        private readonly teamWCRHDbContext context;
        private readonly IMapper mapper;
        
        public FeedController(IConfiguration config,teamWCRHDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeed([FromBody]FeedResource feed)
        {
            // Model Validation For DataAnnotations
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Businness Logic Validation
            // if(true) {
            //     ModelState.AddModelError("..","error");
            //     return BadRequest(ModelState);
            // }

            var realFeed = mapper.Map<FeedResource, Feed>(feed);
            realFeed.CreatedOn = Convert.ToString(DateTime.Now);
            await context.Feeds.AddAsync(realFeed);
            await context.SaveChangesAsync();
            return Ok(realFeed);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeed()
        {
            var feeds = await context.Feeds.ToListAsync();
            
            var returnFeed = mapper.Map<List<Feed>, List<FeedResource>>(feeds);

            return Ok(returnFeed);

        }
        
        [HttpPut]
        public async Task<IActionResult> GetFeedByProjectId([FromBody]int[] projects)
        {

            var feeds = await context.Feeds.Where(u => projects.Contains(u.ProjectId.Value)).ToListAsync();
            
            var returnFeed = mapper.Map<List<Feed>, List<FeedResource>>(feeds);

            return Ok(returnFeed);

        }
    }
}