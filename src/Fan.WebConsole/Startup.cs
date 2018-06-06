using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Fan.Addins;

namespace Fan.WebConsole
{
    public class Startup
    {

        public static bool NoDashboard { get; set; } = false;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            string s = ConfigurationManager.ConnectionStrings["hangfire"].ConnectionString;
            if (!string.IsNullOrEmpty(s))
                services.AddFan(s);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            string s = ConfigurationManager.AppSettings["AddinPath"].Trim();
            if (!string.IsNullOrEmpty(s))
                app.UseFan(s, !NoDashboard);
        }

    }
}
