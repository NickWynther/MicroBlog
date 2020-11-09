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
        public ICollection<Comment> Comments { get; set; }

    }
}
