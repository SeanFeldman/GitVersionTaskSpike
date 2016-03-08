using System;
using System.Reflection;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            //
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
