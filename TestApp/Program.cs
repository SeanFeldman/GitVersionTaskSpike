using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName().Name;
            var gitVersionInformationType = assembly.GetType(assemblyName + ".GitVersionInformation");
            var fields = gitVersionInformationType.GetFields();

            foreach (var field in fields)
            {
                Trace.WriteLine(string.Format("{0}: {1}", field.Name, field.GetValue(null)));
            }

            var versionField = gitVersionInformationType.GetField("Minor");
            Trace.WriteLine(versionField.GetValue(null));

            Console.ReadLine();
        }
    }
}
