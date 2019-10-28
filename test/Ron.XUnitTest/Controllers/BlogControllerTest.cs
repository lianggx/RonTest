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
        [InlineData(1)]
        public async Task Detail(int id)
        {
            var result = await GetData($"/api/blog/detail/{id}");

            Assert.Equal(0, result.Code);
        }

        [Fact]
        public async Task List()
        {
            var result = await PostData("/api/blog/list/", new { Page = 1, PageSize = 20 });

            Assert.Equal(0, result.Code);
        }

        [Fact]
        public async Task Add()
        {
            var result = await PostData("/api/blog/add/", new { Title = "", Content = "" });

            Assert.Equal(0, result.Code);
        }

        [Fact]
        public async Task Edit()
        {
            var result = await PostData("/api/blog/edit/", new { Id = 0, Title = "", Content = "" });

            Assert.Equal(0, result.Code);
        }
    }
}
