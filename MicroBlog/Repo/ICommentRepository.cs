using MicroBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBlog.Repo
{
    public interface ICommentRepository
    {
        void AddAsync(Comment comment);
        Task SaveAsync();
        public IEnumerable<Comment> GetForPost(int id);

    }
}
