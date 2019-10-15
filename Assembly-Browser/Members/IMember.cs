using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    interface IMember
    {
        string Attributes { get; }
        string Type { get; }
        string Name { get; }
    }
}
