# 说明

该项目主要是用于尝试C#中我还没有遇到的语法问题

# using
关于using的使用网上资料也很多，我这里主要是增对using包装块的进行一个解释。
对using命名空间的引入和别名等我就不在这里做解释。
```csharp
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
```
从上面的代码中可以看到使用了UsingBlock的实例是否用using做了一个测试。

测试结果：

- UsingBlock block = new UsingBlock()

这个是常见的实例化我就不做解释，直接由内部GC托管处理

-  using UsingBlock block = new UsingBlock();

这里和常规的using写法很相似，但是在释放的时候时机是不一样的。
这种写法是取定义的当前`作用域`执行完时才会自动去释放。

- using (UsingBlock block = new UsingBlock())

```csharp
using (UsingBlock block = new UsingBlock())
{
    block.SayHello();
}
```
using包装的代码块一执行完就会调用`Dispose()`方法。
