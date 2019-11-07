using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Ron.Blogs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Ron.XUnitTest
{
    public abstract class BaseTest
    {
        protected readonly TestServer server;
        protected readonly HttpClient httpClient;
        protected readonly ITestOutputHelper output = null;

        public BaseTest(ITestOutputHelper output)
        {
            this.output = output;
            if (server == null)
                server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            httpClient = server.CreateClient();
            httpClient.DefaultRequestHeaders.Add("token", "66dba5a7e893977b");
        }

        public async Task<APIReturn> PostData(string action, dynamic body)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var data = await httpClient.PostAsync(action, content);
            var result = await data.Content.ReadAsStringAsync();
            var resultObj = JsonConvert.DeserializeObject<APIReturn>(result);

            return resultObj;
        }

        public async Task<APIReturn> GetData(string action)
        {
            var data = await httpClient.GetAsync(action);
            var result = await data.Content.ReadAsStringAsync();
            var resultObj = JsonConvert.DeserializeObject<APIReturn>(result);

            return resultObj;
        }
    }
}
