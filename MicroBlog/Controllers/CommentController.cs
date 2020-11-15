using MicroBlog.Models;
using MicroBlog.Models.Input;
using MicroBlog.Repo;
using Microsoft.AspNetCore.Http;
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
        private readonly ICommentRepository _repo;
        public CommentController(BlogDbContext blogContext)
        {
            _repo = new CommentRepository(blogContext);
        }

        // GET api/comment/5  -- all coments for post 5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Comment>> Get(int id)
        {
            var comments = _repo.GetForPost(id);

            if (comments == null)
            {
                return NotFound();
            }

            return comments;
        }
 
        // POST api/comment
        [HttpPost]
        public async Task<ActionResult<Comment>> Post(CommentInput input)
        {
            var comment = new Comment(input);
            _repo.AddAsync(comment);
            await _repo.SaveAsync();
            return comment;
        }
    }
}
