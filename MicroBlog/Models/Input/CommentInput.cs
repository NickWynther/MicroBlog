using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBlog.Models.Input
{
    public class CommentInput
    {
        private const string _anonymousUsername = "Anonymous";
        public string Author { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }

    }
}
