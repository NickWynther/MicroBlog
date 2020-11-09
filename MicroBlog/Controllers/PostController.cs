using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroBlog.Models;
using MicroBlog.Models.View;
using MicroBlog.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private BlogDbContext _repo;
        private const string _anonymousUsername = "Anonymous";
        public PostController(BlogDbContext repo)
        {
            _repo = repo;
        }

        // GET api/post -- ALL POSTS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            return await _repo.Posts.ToListAsync();
        }

        // GET api/post/today -- Posted last 24h
        [HttpGet]
        [Route("today")]
        public async Task<ActionResult<IEnumerable<Post>>> Today()
        {
            var yesterday = DateTime.Now.AddDays(-1);
            return await _repo.Posts.Where(x => x.Time.Date > yesterday).ToListAsync();
        }

        // GET api/post/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            var post = await _repo.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return new ObjectResult(post);
        }

        // POST api/post
        [HttpPost]
        public async Task<ActionResult<Post>> Post(PostView postView)
        {
            if (postView == null)
            {
                return BadRequest();
            }

            if (postView.Author.Length < 1)
            {
                postView.Author = _anonymousUsername;
            }

            var post = new Post()
            {
                Title = postView.Title,
                Text = postView.Text,
                Author = postView.Author,
                Time = DateTime.Now
            };

            _repo.Posts.Add(post);
            await _repo.SaveChangesAsync();
            return Ok(post);
        }
    }
}
