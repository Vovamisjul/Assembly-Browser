using AssemblyInfo.Members;
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
                    properties.Add(new Property(property.Name, property.ReflectedType.Name, property.Attributes.ToString(), 
                        property.SetMethod.Attributes.ToString(), property.GetMethod.Attributes.ToString()));
                }
                var methods = new List<Method>();
                foreach (var method in type.GetMethods())
                {
                    methods.Add(new Method(method.Attributes.ToString(), method.ReturnType.ToString(), method.Name, method.GetParameters().Select(parameter => parameter.ParameterType.ToString()).ToArray()));
                }
                types.Add(new TypeInfo(methods.ToArray(), fields.ToArray(), properties.ToArray(), type.FullName));
            }
            return new Assembly(types.ToArray(), assembly.FullName);
        }
    }
}
