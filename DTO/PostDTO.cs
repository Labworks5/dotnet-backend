using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_HelloWorld.DTO
{
    public class PostDTO
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; } = string.Empty;
    }
}