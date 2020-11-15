using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroBlog.Models.Input
{
    public class PostInput
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

    }
}
