using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ron.Blogs.Models
{
    public class BlogViewModel
    {
        public int? Id { get; set; }
        [Required] public string Title { get; set; }
        [Required, MaxLength(4000)] public string Content { get; set; }
    }
}
