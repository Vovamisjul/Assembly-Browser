using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class Loader
    {
        public Assembly Load(string file)
        {
            var assembly = System.Reflection.Assembly.LoadFrom(file);
            var types = new List<TypeInfo>();
            foreach (var type in assembly.ExportedTypes)
            {
                var fields = new List<Field>();
                foreach (var field in type.GetFields())
                {
                    fields.Add(new Field(field.Name, field.ReflectedType.Name, field.Attributes.ToString()));
                }
                var properties = new List<Property>();
                foreach (var property in type.GetProperties())
                {
                    fields.Add(new Field(property.Name, property.ReflectedType.Name, property.Attributes.ToString()));
                }
                types.Add(new TypeInfo(null, fields.ToArray(), properties.ToArray()));
            }
            return new AssemblyInfo.Assembly(types.ToArray());
        }
    }
}
