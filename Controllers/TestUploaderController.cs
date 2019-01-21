using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using teamWcrh.Controllers.Resources.File;
using teamWcrh.Persistence;

namespace teamWcrh.Controllers
{
    [Route("api/[controller]")] 
    public class TestUploaderController : Controller
    {
        private IConfiguration _config;
        private readonly teamWCRHDbContext context;
        private readonly IMapper mapper;
        private IHostingEnvironment _hostingEnvironment;

        
        public TestUploaderController(IHostingEnvironment hostingEnvironment,IConfiguration config,teamWCRHDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            _config = config;  
            _hostingEnvironment = hostingEnvironment;
        }
       
        

        // [HttpPost, DisableRequestSizeLimit]
        // public async Task<IActionResult> Upload(List<IFormFile> files)
        // {
            
        //     try
        //     {
        //         var count = 0;
        //         var result = new List<FileUploadResource>();
        //         foreach(var file in files){
        //             count++;
        //         var path = Path.Combine(Directory.GetCurrentDirectory(),
        //         "wwwroot/Upload",file.FileName);
        //         var stream = new FileStream(path,FileMode.Create);
        //        await file.CopyToAsync(stream);
        //        result.Add(new FileUploadResource(){ Name = file.FileName, Length = file.Length});
        //         }
        //        return Ok(count);
        //     }
        //     catch (System.Exception ex)
        //     {
        //       return BadRequest();
        //     }
        // }

         [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file,string name)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/Upload",file.FileName);
                var stream = new FileStream(path,FileMode.Create);
               await file.CopyToAsync(stream);
               return Ok(new { length = file.Length, name = name});
            }
            catch (System.Exception ex)
            {
              return BadRequest();
            }
        }
    }
}