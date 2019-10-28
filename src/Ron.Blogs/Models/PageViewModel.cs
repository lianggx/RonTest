using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ron.Blogs.Models
{
    public class PageViewModel
    {
        [Range(1, int.MaxValue)] public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
