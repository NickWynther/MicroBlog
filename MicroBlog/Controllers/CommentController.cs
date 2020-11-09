using MicroBlog.Models;
using MicroBlog.Models.View;
using MicroBlog.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBlog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private BlogDbContext _repo;
        private const string _anonymousUsername = "Anonymous";
        public CommentController(BlogDbContext repo)
        {
            _repo = repo;
        }

        // GET api/comment/5  -- all coments for post 5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Comment>>> Get(int id)
        {
            var comments = _repo.Comments.Where( x => x.PostId == id);
            if (comments == null)
            {
                return NotFound();
            }

            var result = await comments.ToListAsync();

            return new ObjectResult(result);
        }

        // POST api/comment
        [HttpPost]
        public async Task<ActionResult<Post>> Post(CommentView commentView)
        {
            if (commentView == null)
            {
                return BadRequest();
            }

            if (commentView.Author.Length < 1)
            {
                commentView.Author = _anonymousUsername;
            }

            var comment = new Comment()
            {
                Text = commentView.Text,
                Author = commentView.Author,
                PostId = commentView.PostId,
                Time = DateTime.Now
            };

            _repo.Comments.Add(comment);
            await _repo.SaveChangesAsync();
            return Ok(comment);
        }
    }
}
