using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class Property : IMember
    {
        public Property(string attributes, string type, string name, string setMethod, string getMethod)
        {
            Attributes = attributes;
            Type = type;
            Name = name;
            SetMethod = setMethod;
            GetMethod = getMethod;
        }
        public string Attributes { get; }
        public string Type { get; }
        public string Name { get; }
        public string SetMethod { get; }
        public string GetMethod { get; }
    }
}
