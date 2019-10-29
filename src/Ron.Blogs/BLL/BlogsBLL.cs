using Ron.Blogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ron.Blogs.BLL
{
    public class BlogsBLL
    {
        public List<BlogViewModel> List { get; set; } = new List<BlogViewModel>();
        public BlogsBLL()
        {
            for (int i = 0; i < 100; i++)
            {
                List.Add(new BlogViewModel
                {
                    Id = i + 1,
                    Title = $"第 {i} 个测试模型",
                    Content = $"这是第 {i} 个模型的内容"
                });
            }
        }
    }
}
