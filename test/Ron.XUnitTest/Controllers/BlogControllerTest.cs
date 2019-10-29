using Ron.Blogs.Models;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Ron.XUnitTest
{
    public class BlogControllerTest : BaseTest
    {

        public BlogControllerTest(ITestOutputHelper output) : base(output)
        {
        }


        [Trait("TestCategory", "CategoryA")]
        [Trait("Priority", "2")]
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(100)]
        public async Task Detail(int id)
        {
            var result = await GetData($"/api/blog/detail/{id}");

            Assert.NotEmpty(result.Data);
        }

        [Trait("Priority", "1")]
        [Trait("TestCategory", "CategoryA")]
        [Fact]
        public async Task List()
        {
            var result = await PostData("/api/blog/list/", new { Page = 1, PageSize = 20 });

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task Add()
        {
            var result = await PostData("/api/blog/add/", new { Title = "测试Add的用例", Content = "这是测试Add的用例" });

            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task Edit()
        {
            var result = await PostData("/api/blog/edit/", new { Id = 10, Title = "修改测试Add的用例", Content = "这是修改测试Add的用例" });

            Assert.NotNull(result.Data);
        }
    }
}
