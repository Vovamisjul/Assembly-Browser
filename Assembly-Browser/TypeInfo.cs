using AssemblyInfo.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class TypeInfo
    {
        public TypeInfo(Method[] methods, Field[] fields, Property[] properties, string name, string attributes)
        {
            Methods = methods;
            Fields = fields;
            Properties = properties;
            Name = name;
            Attributes = attributes;
        }
        public string Name { get; }
        public string Attributes { get; }
        public Method[] Methods { get; }
        public Field[] Fields { get; }
        public Property[] Properties { get; }
        public override string ToString()
        {
            return Attributes + " " + Name;
        }
    }
}
