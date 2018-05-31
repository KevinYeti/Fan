using Fan.Interface;
using System.Reflection;

namespace Minter.Quartz.Model
{
    public class AddinInfo
    {
        public string Name { get; set; }
        public string File { get; set; }

        public Assembly Assembly { get; set; }
    }
}
