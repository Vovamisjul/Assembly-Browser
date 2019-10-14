using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class Field :IMember
    {
        public Field(string attributes, string type, string name)
        {
            this.attributes = attributes;
            this.type = type;
            this.name = name;
        }
        public string attributes { get; }
        public string type { get; }
        public string name { get; }
    }
}
