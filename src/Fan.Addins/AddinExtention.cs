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
            app.UseHangfireDashboard();

            AssemblyResolver.Init(path);
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolver.ResolveAssembly;

            return app;
        }
    }
}
