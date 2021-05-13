using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Jonny.AllDemo.Reflection.Mocks
{
    public class ModuleMock
    {
        public static void Main1()
        {
            ModuleMock module = new ModuleMock();
            Module module1 = module.GetType().Module;
            Console.WriteLine($"The current module is {module1}.");

            // Module集合
            Assembly assembly = typeof(ModuleMock).Assembly;
            Console.WriteLine($"The current excuting assambly is {assembly}.");
            Module[] modules = assembly.GetModules();
            foreach (var m in modules)
            {
                Console.WriteLine($"The assmbly contains the {m.Name} module");
            }
            Console.ReadLine();
        }
    }
}
