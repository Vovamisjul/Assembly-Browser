using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class Assembly
    {
        public Assembly(TypeInfo[] types)
        {
            this.types = types;
        }
        TypeInfo[] types { get; }
    }
}
