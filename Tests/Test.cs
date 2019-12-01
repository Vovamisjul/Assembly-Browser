using AssemblyInfo;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class Test
    {
        Loader _loader = new Loader();
        const string directory = "D:\\spp\\Assembly-Browser\\Tests\\dlls\\";
        [Test]
        public void When_Interface_Expect_ShowIt()
        {
            var a = Directory.GetCurrentDirectory();
            var assembly = _loader.Load(directory + "IGenerator.dll");
            Assert.Multiple(() =>
            {
                Assert.That(assembly.ToString().StartsWith("Assembly IGenerator"));
                Assert.AreEqual(assembly.Namespaces["Generation"].Types[0].ToString(), "public interface Generation.IGenerator");
                Assert.AreEqual(assembly.Namespaces["Generation"].Types[0].Methods[0].ToString(), "public abstract System.Object Generate()");
                Assert.AreEqual(assembly.Namespaces["Generation"].Types[0].Methods[1].ToString(), "public abstract System.Type GeneratedType()");
            });
        }
        [Test]
        public void When_AbstractClass_Expect_ShowIt()
        {
            var assembly = _loader.Load(directory + "abstractClass.dll");
            Assert.Multiple(() =>
            {
                Assert.That(assembly.ToString().StartsWith("Assembly abstractClass"));
                Assert.AreEqual(assembly.Namespaces["abstractClass"].Types[0].ToString(), "public abstract class abstractClass.Class1");
                Assert.AreEqual(assembly.Namespaces["abstractClass"].Types[0].Methods[0].ToString(), "public abstract System.Void kek()");
                Assert.AreEqual(assembly.Namespaces["abstractClass"].Types[0].Methods[1].ToString(), "public System.Int32 lol()");
            });
        }
        [Test]
        public void When_ManyClasses_Expect_ShowIt()
        {
            var assembly = _loader.Load(directory + "Generators.dll");
            Assert.Multiple(() =>
            {
                Assert.AreEqual(assembly.Namespaces["Generators"].Types[0].ToString(), "public class Generators.ByteGenerator");
                Assert.AreEqual(assembly.Namespaces["Generators"].Types[1].ToString(), "public class Generators.DateTimeGenerator");
                Assert.AreEqual(assembly.Namespaces["Generators"].Types[2].ToString(), "public class Generators.LongGenerator");
            });
        }
        [Test]
        public void When_NoGet_Expect_ShowIt()
        {
            var assembly = _loader.Load(directory + "testclasses.dll");
            Assert.AreEqual(assembly.Namespaces["namespace2"].Types[0].Properties[0].ToString(), "a{ public set; }");
        }
    }
}
