using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fan.WebConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            if (args.Any(g => g.Trim().ToLower().Contains("nodashboard"))) { 
                Startup.NoDashboard = true;
            }

            return WebHost.CreateDefaultBuilder(new string[] { })
                    .UseStartup<Startup>()
                    .UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 3000);
                    })
                    .Build();
        }
    }
}
