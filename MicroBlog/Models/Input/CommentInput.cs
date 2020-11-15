using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBlog.Models.Input
{
    public class CommentInput
    {
        public string Author { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int PostId { get; set; }

    }
}
