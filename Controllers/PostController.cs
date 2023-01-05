using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNet_HelloWorld.Models;
using DotNet_HelloWorld.DTO;

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

        [HttpGet("GetAllPosts")]
        public IActionResult GetAllPosts()  
        {
            var posts = appDbContext.Posts.ToList();
            return Ok(posts);           
        }

        [HttpGet("GetPostById/{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = appDbContext.Posts.FirstOrDefault(p => p.PostId == id);
            return Ok(post);
        }

        [HttpDelete("DeletePostById/{id}")]
        public IActionResult DeletePostById(int id)
        {
            var post = appDbContext.Posts.FirstOrDefault(p => p.PostId == id);
            if (post != null){
                appDbContext.Remove(post);
                appDbContext.SaveChanges(); 
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost("CreatePost")]
        public IActionResult CreatePost(Post _post)
        {
            var post = appDbContext.Posts.FirstOrDefault(p => p.PostId == _post.PostId);
            if (post != null){
                post.Title = _post.Title;
                post.Content = _post.Content;
                appDbContext.SaveChanges();   
            }
            else {
                appDbContext.Posts.Add(_post);
                appDbContext.SaveChanges();
            }
            return Ok(true);
        }
    }

    
}