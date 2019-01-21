using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using teamWcrh.Controllers.Resources.Event;
using teamWcrh.Models;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
    [Route("api/[controller]")] 
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

         [HttpPost]
        public async Task<IActionResult> AddEvent([FromForm]EventResource eventResourse)
        {
            var realEvent = mapper.Map<EventResource, Event>(eventResourse);
            realEvent.CreatedOn = DateTime.Now;
            if(eventResourse.ImageFile != null){
                realEvent.Image = await SaveImage(eventResourse.ImageFile);
            }
            await context.Events.AddAsync(realEvent);
            await context.SaveChangesAsync();
            return Ok(realEvent); 
        }

         [HttpGet]
        public async Task<IActionResult> GetAllEvent()
        {
            var Events = await context.Events.ToListAsync();
            
            var returnEvent = mapper.Map<List<Event>, List<EventResource>>(Events);

            return Ok(returnEvent);

        }
        [HttpPut]
        public async Task<IActionResult> GetEventByProjectId([FromBody]int[] projects)
        {

            var Events = await context.Events.Where(u => projects.Contains(u.ProjectId.Value)).ToListAsync();
            
            var returnEvent = mapper.Map<List<Event>, List<EventResource>>(Events);

            return Ok(returnEvent);

        }

        public async Task<string> SaveImage(IFormFile file){
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/Upload",file.FileName);
                var stream = new FileStream(path,FileMode.Create);
               await file.CopyToAsync(stream);
               return file.FileName;
            }
            catch (System.Exception ex)
            {
              return null;
            }
        }

    }

}