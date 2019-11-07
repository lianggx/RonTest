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

        [Theory]
        [InlineData(100)]
        public async Task Detail(int id)
        {
            var result = await GetData($"/api/blog/detail/{id}");

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task List()
        {
            var data = new { Page = 1, PageSize = 20 };
            var result = await PostData("/api/blog/list/", data);

            Assert.NotEmpty(result.Data);
        }

        [Fact]
        public async Task Add()
        {
            var result = await PostData("/api/blog/add/", new { Title = "����Add������", Content = "���ǲ���Add������" });

            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task Edit()
        {
            var result = await PostData("/api/blog/edit/", new { Id = 10, Title = "�޸Ĳ���Add������", Content = "�����޸Ĳ���Add������" });

            Assert.NotNull(result.Data);
        }
    }
}
