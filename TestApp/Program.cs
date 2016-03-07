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
            var assembly = Assembly.GetEntryAssembly();
            var assemblyName = assembly.GetName().Name;
            var gitVersionInformationType = assembly.GetType(assemblyName + ".GitVersionInformation");
            var fields = gitVersionInformationType.GetFields();

            foreach (var field in fields)
            {
                Console.WriteLine($"{field.Name}: {field.GetValue(null)}");
            }

            var versionField = gitVersionInformationType.GetField("Minor");
            Console.WriteLine(versionField.GetValue(null));

            Console.ReadLine();
        }
    }
}
