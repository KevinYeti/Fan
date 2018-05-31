using Fan.Addins.Filters;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fan.Addins
{
    public static class AddinExtension
    {
        public static IServiceCollection AddFan(this IServiceCollection services, string connection)
        {
            services.AddHangfire(x => x.UseSqlServerStorage(connection));
            return services;
        }

        public static IApplicationBuilder UseFan(this IApplicationBuilder app, string path)
        {
            app.UseHangfireServer();
            app.UseHangfireDashboard("/fan", new DashboardOptions()
            {
                Authorization = new[] { new HangfireAuthorizeFilter() }
            });

            AssemblyResolver.Init(path, AssemblyResolver.ResolveAssembly);

            return app;
        }
    }
}
