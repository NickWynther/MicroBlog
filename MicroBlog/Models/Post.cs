using MicroBlog.Models.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =2)]
        public string Title { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 2)]
        public string Text { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Author { get; set; }
        [Required]
        public DateTime Time { get; set; }

        public Post() {}
        private const string _anonymousUsername = "Anonymous";
        public Post(PostInput input)
        {
            Title = input.Title;
            Text = input.Text;
            Author = (input.Author.Length < 1) ? _anonymousUsername : input.Author;
            Time = DateTime.Now;
        }
    }
}
