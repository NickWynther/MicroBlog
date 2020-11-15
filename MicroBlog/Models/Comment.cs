using MicroBlog.Models.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Author { get; set; }
        [Required]
        [StringLength(5000, MinimumLength = 2)]
        public string Text { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public int PostId { get; set; }

        public Comment()
        {
        }
        private const string _anonymousUsername = "Anonymous";
        public Comment(CommentInput input)
        {
            Text = input.Text;
            Author = (input.Author.Length < 1) ? _anonymousUsername : input.Author;
            PostId = input.PostId;
            Time = DateTime.Now;
        }
    }
}
