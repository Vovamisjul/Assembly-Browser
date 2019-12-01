using AssemblyInfo.Members;
using System;
using System.Collections.Generic;
using System.IO;
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
            var namespaces = new Dictionary<string, NamespaceInfo>();
            foreach (var type in assembly.ExportedTypes)
            {
                var fields = new List<Field>();
                foreach (var field in type.GetFields())
                {
                    fields.Add(new Field(GetFieldAttributes(field.Attributes), field.ReflectedType.Name, field.Name));
                }
                var properties = new List<Property>();
                foreach (var property in type.GetProperties())
                {
                    properties.Add(new Property(property.Name,
                        property.SetMethod != null ? GetMethodAttributes(property.SetMethod.Attributes) : null,
                        property.GetMethod != null ? GetMethodAttributes(property.GetMethod.Attributes) : null));
                }
                var methods = new List<Method>();
                foreach (var method in type.GetMethods())
                {
                    methods.Add(new Method(GetMethodAttributes(method.Attributes), method.ReturnType.ToString(), method.Name, 
                        method.GetParameters().Select(parameter => parameter.ParameterType.ToString()).ToArray()));
                }
                if (namespaces.ContainsKey(type.Namespace))
                {
                    namespaces[type.Namespace].Types.Add(new TypeInfo(methods, fields, properties, type.FullName, GetTypeAttributes(type.Attributes)));
                }
                else
                {
                    namespaces.Add(type.Namespace, new NamespaceInfo(type.Namespace, 
                        new List<TypeInfo> { new TypeInfo(methods, fields, properties, type.FullName, GetTypeAttributes(type.Attributes)) }));
                }
            }
            return new Assembly(namespaces, assembly.FullName);
        }

        private string GetTypeAttributes(TypeAttributes attr)
        {
            string result = "";
            if (attr.HasFlag(TypeAttributes.Public))
                result += "public ";
            if (attr.HasFlag(TypeAttributes.Sealed))
                result += "sealed ";
            if (attr.HasFlag(TypeAttributes.Abstract))
            {
                if (attr.HasFlag(TypeAttributes.Interface))
                    result += "interface";
                else
                    result += "abstract class";
            }
            else
                result += "class";
            return result;
        }

        private string GetMethodAttributes(MethodAttributes attr)
        {
            string result = "";
            if (attr.HasFlag(MethodAttributes.Public))
                result += "public ";
            else
            {
                if (attr.HasFlag(MethodAttributes.Family))
                    result += "protected ";
                else
                    result += "private";
            }
            if (attr.HasFlag(MethodAttributes.Static))
                result += "static ";
            if (attr.HasFlag(MethodAttributes.Virtual))
            {
                if (attr.HasFlag(MethodAttributes.Abstract))
                    result += "abstract ";
                else
                    result += "virtual ";
            }
            if (attr.HasFlag(MethodAttributes.Final))
                result += "sealed ";
            return result.Remove(result.Length-1);
        }

        private string GetFieldAttributes(FieldAttributes attr)
        {
            string result = "";
            if (attr.HasFlag(FieldAttributes.Public))
                result += "public ";
            else
            {
                if (attr.HasFlag(FieldAttributes.Family))
                    result += "protected ";
                else
                    result += "private";
            }
            if (attr.HasFlag(FieldAttributes.Assembly))
                result += "iternal ";
            if (attr.HasFlag(FieldAttributes.Static))
                result += "static ";
            if (attr.HasFlag(FieldAttributes.Literal))
                result += "const ";
            return result.Remove(result.Length - 1);
        }
    }
}