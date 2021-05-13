using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace Jonny.AllDemo.Reflection.Mocks
{
    class MymemberinfoMock
    {
        public static void Main1()
        {
            Console.WriteLine("\nReflection.MemberInfo");
            // Gets the Type and MemberInfo.            
            Type myType = typeof(File);                        
            MemberInfo[] mymemberinfoarray = myType.GetMembers();
            // Gets and displays the DeclaringType method.
            Console.WriteLine("\nThere are {0} members in {1}.",
                mymemberinfoarray.Length, myType.FullName);
            Console.WriteLine("{0}.", myType.FullName);
            if (myType.IsPublic)
            {
                Console.WriteLine("{0} is public.", myType.FullName);
            }
            foreach (var item in mymemberinfoarray)
            {
                Console.WriteLine("Member Name is:"+item.Name);
            }
        }
    }
}