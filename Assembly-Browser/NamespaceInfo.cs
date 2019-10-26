using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class NamespaceInfo
    {
        public string Name {get; }
        public List<TypeInfo> Types { get; }
        public NamespaceInfo(string name, List<TypeInfo> types)
        {
            Name = name;
            Types = types;
        }
        public override string ToString()
        {
            return "namespace " + Name;
        }

    }
}
