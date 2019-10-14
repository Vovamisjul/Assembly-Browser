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
        public TypeInfo(Method[] methods, Field[] fields, Property[] properties)
        {
            this.methods = methods;
            this.fields = fields;
            this.properties = properties;
        }
        Method[] methods { get; }
        Field[] fields { get; }
        Property[] properties { get; }
    }
}
