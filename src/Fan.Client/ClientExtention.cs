using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fan.Client
{
    public static class ClientExtention
    {
        public static IServiceCollection AddFan(this IServiceCollection services, string connection)
        {
            Job.Init(connection);
            Console.WriteLine("Fan started with: " + connection);
            
            return services;
        }

    }
}
