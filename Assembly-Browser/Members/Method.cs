using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo.Members
{
    public class Method
    {
        public Method(string attributes, string returnType, string name, string[] parameters)
        {
            Attributes = attributes;
            ReturnType = returnType;
            Name = name;
            Parameters = parameters;
        }
        public string Attributes { get; }
        public string ReturnType { get; }
        public string Name { get; }
        public string[] Parameters { get; }
        public override string ToString()
        {
            return Attributes + " " + ReturnType + " " + Name + "(" + String.Join(", ", Parameters) + ")";
        }
    }
}
