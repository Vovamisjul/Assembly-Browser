using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    interface IMember
    {
        string attributes { get; }
        string type { get; }
        string name { get; }
    }
}
