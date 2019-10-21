using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class Property : Member
    {
        public Property(string name, string type,string setMethod, string getMethod)
        {
            Type = type;
            Name = name;
            SetMethod = setMethod;
            GetMethod = getMethod;
        }
        public string SetMethod { get; }
        public string GetMethod { get; }
        public override string ToString()
        {
            return base.ToString() + "{ " + GetMethod + " get; " + SetMethod + " set; }";
        }
    }
}
