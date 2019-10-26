using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class Assembly
    {
        public Assembly(Dictionary<string, NamespaceInfo> namespaces, string name)
        {
            Namespaces = namespaces;
            Name = name;
        }
        public Dictionary<string, NamespaceInfo> Namespaces { get; }
        public string Name { get; }
        public override string ToString()
        {
            return "Assembly " + Name;
        }
    }
}
