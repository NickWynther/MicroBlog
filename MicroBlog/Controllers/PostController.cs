using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MicroBlog.Models;
using MicroBlog.Models.Input;
using MicroBlog.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostRepository _repo;
        public PostController(BlogDbContext blogContext)
        {
            _repo = new PostRepository(blogContext);
        }

        // GET api/post -- ALL POSTS
        [HttpGet]
        public async Task<IEnumerable<Post>> GetAll() 
            => await _repo.GetAllAsync();

        // GET api/post/today -- Posted last 24h
        [HttpGet]
        [Route("today")]
        public async Task<IEnumerable<Post>> Today()
        {
            var yesterday = DateTime.Now.AddDays(-1);
            var todayPosts = await _repo.GetYoungerThanAsync(yesterday);
            return todayPosts;
        }

        //GET api/post/random -- Random post
        [HttpGet]
        [Route("random")]
        public Post Random() => _repo.PickRandom();
 

        // GET api/post/5 
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            var post = await _repo.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        //GET api/Post/search?search=
        [HttpGet("search")]
        public async Task<ActionResult<Post>> Search(string search)
        {
            var posts = await _repo.GetTitleContainAsync(search);
            if (posts == null)
            {
                return NotFound();
            }

            return new ObjectResult(posts);
        }

        // POST api/post
        [HttpPost]
        public async Task<Post> Post(PostInput input)
        {
            var post = new Post(input);
             _repo.AddAsync(post);
            await _repo.SaveAsync();
            return post;
        }
    }
}
