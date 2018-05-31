using Fan.Interface;
using Minter.Quartz.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Fan.Addins
{
    public static class AddinLoader
    {
        public static AddinInfo Load(string file)
        {
            try
            {
                byte[] buffer = File.ReadAllBytes(file);
                Assembly asm = Assembly.Load(buffer);

                if (asm != null && AddinLoader.ContainsAddin(asm))
                {
                    var info = new AddinInfo();
                    info.Name = asm.FullName;
                    info.File = file;
                    info.Assembly = asm;
                    return info;

                }
                else
                    throw new Exception("Can not load assembly.");
            }
            catch
            {
                Console.WriteLine("[Error] Not an addin file: " + file);
                return null;
            }
        }

        private static bool ContainsAddin(Assembly asm)
        {
            if (asm == null)
                return false;
            else
            {
                var types = asm.GetTypes();
                if (types == null || types.Length == 0)
                    return false;
                else
                {
                    foreach (var type in types)
                    {
                        if (!type.IsClass || type.IsNotPublic)
                            continue;

                        Type[] interfaces = type.GetInterfaces();//加载该类型的接口
                        if (interfaces.Contains(typeof(IAddin)))
                            return true;
                    }
                }

            }

            return false;
        }
    }
}
