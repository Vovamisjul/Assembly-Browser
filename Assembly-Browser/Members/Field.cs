using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class Field : Member
    {
        public Field(string attributes, string type, string name)
        {
            Attributes = attributes;
            Type = type;
            Name = name;
        }
    }
}
