using System;

namespace Jonny.AllDemo.Grammar
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                UsingBlock block = new UsingBlock();
                block.SayHello();
            }
            {
                using UsingBlock block = new UsingBlock();
                {
                    block.SayHello();
                }
                block.SayHello();
            }
            using (UsingBlock block = new UsingBlock())
            {
                block.SayHello();
            }
            Console.ReadLine();
        }

        class UsingBlock : IDisposable
        {
            public void SayHello()
            {
                Console.WriteLine("Hello");
            }
            public void Dispose()
            {
                Console.WriteLine("UsingBlock释放了");
            }

        }
    }
}
