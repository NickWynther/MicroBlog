using MicroBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBlog.Repo
{
    public interface IPostRepository
    {
        Post PickRandom();
        void AddAsync(Post post);
        Task<Post> GetByIdAsync(int id);
        Task<List<Post>> GetYoungerThanAsync(DateTime date);
        Task<List<Post>> GetAllAsync();
        Task<List<Post>> GetTitleContainAsync(string search);

    }
}
