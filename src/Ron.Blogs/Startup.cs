using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Ron.Blogs.BLL;
using Ron.Blogs.Extensions;

namespace Ron.Blogs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DefaultSerializer();
        }

        private void DefaultSerializer()
        {
            JsonConvert.DefaultSettings = () =>
            {
                var st = new JsonSerializerSettings
                {
                    Formatting = Formatting.None
                };
                st.Converters.Add(new StringEnumConverter());
                st.Converters.Add(new BooleanConverter());
                st.Converters.Add(new DateTimeConverter());
                st.ContractResolver = new LowercaseContractResolver();

                return st;
            };
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<BlogsBLL>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
