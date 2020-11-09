using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBlog.Models.View
{
    public class CommentView
    {
        public string Author { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }
    }
}
