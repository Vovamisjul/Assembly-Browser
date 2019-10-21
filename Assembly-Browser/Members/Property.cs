using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class Property
    {
        public Property(string name, string setMethod, string getMethod)
        {
            Name = name;
            SetMethod = setMethod;
            GetMethod = getMethod;
        }
        public string Name { get; protected set; }
        public string SetMethod { get; }
        public string GetMethod { get; }
        public override string ToString()
        {
            return Name + "{ " + GetMethod + " get; " + SetMethod + " set; }";
        }
    }
}
