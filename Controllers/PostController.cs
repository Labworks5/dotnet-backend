using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNet_HelloWorld.Models;


namespace DotNet_HelloWorld.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public PostController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        private static readonly string[] Summaries = new[]
            {
                "ett", "två", "tree", "fyra", "fem", "sex", "sju", "åtta", "nio", "tio"
            };



       /* [HttpGet("GetPosts")]
        public async Task<ActionResult<List<PostDTO>>> Get()
        {

        } */

        [HttpGet("GetTest")]
        public string Get()
        {

            return Summaries[Random.Shared.Next(Summaries.Length)];
        }
    }
}