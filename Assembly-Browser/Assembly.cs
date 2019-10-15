using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class Assembly
    {
        public Assembly(TypeInfo[] types, string name)
        {
            Types = types;
            Name = name;
        }
        public TypeInfo[] Types { get; }
        public string Name { get; }
    }
}
