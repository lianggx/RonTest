using Ron.Blogs;
using Ron.Blogs.Controllers;
using Ron.Blogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Ron.XUnitTest
{
    public class _BlogControllerTest
    {
        private readonly BlogController blogController;
        private readonly ITestOutputHelper output;
        public _BlogControllerTest(ITestOutputHelper output)
        {
            this.output = output;
            this.blogController = new BlogController(new Blogs.BLL.BlogsBLL());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public void Detail(int id)
        {
            var result = (APIReturn)this.blogController.Detail(id);
            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public void List()
        {
            var result = (APIReturn)this.blogController.List(new PageViewModel { Page = 1, PageSize = 20 });

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public void Add()
        {
            var result = (APIReturn)this.blogController.Add(new BlogViewModel { Title = "测试Add的用例", Content = "这是测试Add的用例" });

            Assert.NotNull(result.Data);
        }

        [Fact]
        public void Edit()
        {
            var result = (APIReturn)this.blogController.Edit(new BlogViewModel { Id = 11, Title = "测试Add的用例", Content = "这是测试Add的用例" });

            Assert.NotNull(result.Data);
        }
    }
}
