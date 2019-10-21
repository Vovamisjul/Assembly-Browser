using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public abstract class Member
    {
        public string Attributes { get; protected set; }
        public string Type { get; protected set; }
        public string Name { get; protected set; }
        public override string ToString()
        {
            return Attributes + " " + Type + " " + Name;
        }
    }
}
