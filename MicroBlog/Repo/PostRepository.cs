using MicroBlog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MicroBlog.Repo
{
    public class PostRepository : IPostRepository
    {
        private BlogDbContext _blogContext;

        public PostRepository(BlogDbContext blogContext)
        {
            _blogContext = blogContext;
        }

        public async void AddAsync(Post post)
        {
            await _blogContext.Posts.AddAsync(post);
        }

        public async Task SaveAsync()
        {
            await _blogContext.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllAsync()
        {
            return await _blogContext.Posts.ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _blogContext.Posts.FindAsync(id);
        }

        public async Task<List<Post>> GetTitleContainAsync(string search)
        {
            return await _blogContext.Posts.Where(x => x.Title.Contains(search)).ToListAsync();
        }

        public async Task<List<Post>> GetYoungerThanAsync(DateTime date)
        {
            return await _blogContext.Posts.Where(x => x.Time.Date > date).ToListAsync();
        }

        public Post PickRandom()
        {
            var postCount = _blogContext.Posts.Count();
            var randomIndex = RandomNumberGenerator.GetInt32(0, postCount);
            var idList = _blogContext.Posts.Select(x => x.Id).ToList();
            var randomId = idList.ElementAt(randomIndex);
            return _blogContext.Posts.Find(randomId);
        }

        
    }
}
