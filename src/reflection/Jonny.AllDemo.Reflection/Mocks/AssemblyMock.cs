using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

public class AssemblyMock
{
    private int flactor;
    public AssemblyMock(int f)
    {
        flactor = f;
    }

    public int SimpleMethod(int x)
    {
        Console.WriteLine("\nAssemblyMock.SimpleMethod({0}) executes.", x);
        return x * flactor;
    }

    public static void Main1(string[] args)
    {
        Assembly assembly = typeof(AssemblyMock).Assembly;
        Console.WriteLine($"程序集全称:{assembly.FullName}");

        AssemblyName assemblyName = assembly.GetName();
        Console.WriteLine($"程序集名称:{assemblyName.Name}");
        // Major:获取当前系统的版本号的【主要】组件的值.Version对象。
        // Minor:获取当前系统的版本号的【次要】组件的值.Version对象。
        Console.WriteLine($"版本:{assemblyName.Version.Major}.{assemblyName.Version.Minor}");

        Console.WriteLine($"CodeBase:{assemblyName.CodeBase}");

        // 创建AssemblyMock实例
        object o = assembly.CreateInstance("AssemblyMock",
            false,
            BindingFlags.ExactBinding, //ExactBinding:指定所提供的参数类型必须与相应的正式参数的类型完全匹配。
            null,
            new object[] { 2 },
            CultureInfo.CurrentCulture,
            null);
        MethodInfo method = assembly.GetType("AssemblyMock").GetMethod("SimpleMethod");
        // 反射调用方法
        var res = method.Invoke(o, new object[] { 3 });
        Console.WriteLine($"SimpleMethod returned {res}.");
        Console.WriteLine($"\nAssembly entry point:{assembly.EntryPoint}");
    }
}

