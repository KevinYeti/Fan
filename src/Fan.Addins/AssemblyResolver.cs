using Minter.Quartz.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Fan.Addins
{
    public static class AssemblyResolver
    {
        public static Dictionary<string, AddinInfo> _map = new Dictionary<string, AddinInfo>();

        public static void Init(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var files = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var addin = AddinLoader.Load(file);
                if (addin != null && !_map.ContainsKey(addin.Name))
                {
                    _map.Add(addin.Name, addin);
                }
            }
        }
        public static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            Console.WriteLine("Resolving assembly: " + args.Name);
            if (_map.ContainsKey(args.Name))
                return _map[args.Name].Assembly;
            else
                return null;
        }
    }
}
