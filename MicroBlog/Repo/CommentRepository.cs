using MicroBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBlog.Repo
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext _blogContext;
        public CommentRepository(BlogDbContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async void AddAsync(Comment comment)
        {
            await _blogContext.Comments.AddAsync(comment);
        }

        public async Task SaveAsync()
        {
            await _blogContext.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetForPost(int id)
        {
            return _blogContext.Comments.Where(x => x.PostId == id).ToList();
        }
    }
}
