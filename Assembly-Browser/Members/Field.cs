using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo.Members
{
    public class Field
    {
        public Field(string attributes, string type, string name)
        {
            Attributes = attributes;
            Type = type;
            Name = name;
        }
        public string Attributes { get; }
        public string Type { get; }
        public string Name { get; }
        public override string ToString()
        {
            return Attributes + " " + Type + " " + Name;
        }
    }
}
