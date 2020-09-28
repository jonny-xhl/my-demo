using System;
using System.Linq.Expressions;

namespace Jonny.AllDemo.LambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            #region invoke

            {
                Console.WriteLine(SumMation1().Invoke(1, 2));

                Console.WriteLine(SumMation2().Invoke(1, 2));

                Console.WriteLine(SumMation3().Invoke(1, 2));
            }

            #endregion

            #region ()

            {
                Console.WriteLine(SumMation1()(1, 2));
                Console.WriteLine(SumMation2()(1, 2));
                Console.WriteLine(SumMation3()(1, 2));
            }

            #endregion

            #region expression测试

            Console.WriteLine($"{nameof(IncreaseByOne)}:{IncreaseByOne(1)}");

            Console.WriteLine($"{nameof(Multiplication)}:{Multiplication(1, 2)}");
            //Complex   (a,b,c,d,e)=>((a+b)*(c-d))%e
            Console.WriteLine($"{nameof(Complex)}:{Complex(1, 2, 3, 4, 3)}");

            var property = CreateProperty<int>("jonny", 25);

            Console.WriteLine(GetPropertyValue(property));

            #endregion


            Console.WriteLine("Hello World!");
        }

        #region 委托尝新

        static Func<int, int, int> SumMation1()
        {
            Func<int, int, int> func = new Func<int, int, int>(
                (int a, int b) => { return a + b; }
            );
            return func;
        }

        static Func<int, int, int> SumMation2()
        {
            Func<int, int, int> func = (int a, int b) => { return a + b; }
                ;
            return func;
        }

        static Func<int, int, int> SumMation3()
        {
            Func<int, int, int> func = (a, b) => a + b;
            return func;
        }

        #endregion

        #region expression 尝新

        // x=>x+1
        static Func<int, int> IncreaseByOne
        {
            get
            {
                //声明一个int类型的参数
                var x = Expression.Parameter(typeof(int), "x");
                //声明递增因子
                var factor = Expression.Constant(1);
                //求和
                var increase = Expression.Add(x, factor);
                //将表达式树组装成lambda表达式树,一个输入,一个输出,所以是Func<int, int>
                var lambda = Expression.Lambda<Func<int, int>>(increase, x);
                Console.WriteLine(lambda);
                //将lambda表达式树编译成Func委托
                var fun = lambda.Compile();
                return fun;
            }
        }

        //(a,b)=>a*3+b*4
        static Func<int, int, int> Multiplication
        {
            get
            {
                //表达式左边  left
                var a = Expression.Parameter(typeof(int), "a");
                var c3 = Expression.Constant(3);
                var left = Expression.Multiply(a, c3);
                //表达式右边  right
                var b = Expression.Parameter(typeof(int), "b");
                var c4 = Expression.Constant(4);
                var right = Expression.Multiply(b, c4);
                // left right 求和
                var add = Expression.Add(left, right);
                //将表达式树组装成lambda表达式树,两个输入,一个输出,固:Func<int, int, int>
                var lambda = Expression.Lambda<Func<int, int, int>>(add, a, b);
                Console.WriteLine(lambda);
                var func = lambda.Compile();
                return func;
            }
        }

        //(a,b,c,d,e)=>((a+b)*(c-d))%e
        static Func<int, int, int, int, int, int> Complex
        {
            get
            {
                //首先进行表达式拆分:由内往外-->(a+b) (c-d)  *  %
                var a = Expression.Parameter(typeof(int), "a");
                var b = Expression.Parameter(typeof(int), "b");
                var leftAdd = Expression.Add(a, b);
                var c = Expression.Parameter(typeof(int), "c");
                var d = Expression.Parameter(typeof(int), "d");
                var rightSubtract = Expression.Subtract(c, d);
                // 中间*号
                var middleMultiply = Expression.Multiply(leftAdd, rightSubtract);
                // 取模%
                var e = Expression.Parameter(typeof(int), "e");
                var modulo = Expression.Modulo(middleMultiply, e);
                // body:modulo  params:a,b,c,d
                var lambda = Expression.Lambda<Func<int, int, int, int, int, int>>(modulo, a, b, c, d, e);
                Console.WriteLine(lambda);
                return lambda.Compile();
            }
        }

        #endregion

        #region 类反射使用表达式创建

        class Property<T> where T : struct
        {
            public Property(string name, T value)
            {
                Name = name;
                Value = value;
                Console.WriteLine("Name:{0};Value:{1}", Name, Value);
            }

            private string Name { get; }

            public T Value { get; }
        }

        static Property<T> CreateProperty<T>(string name, T value) where T : struct
        {
            var newExpression =
                Expression.New(typeof(Property<T>).GetConstructor(new[] {typeof(string), typeof(T)})!,
                    Expression.Constant(name),
                    Expression.Constant(value)
                );
            var lambda = Expression.Lambda<Func<Property<T>>>(newExpression);
            Console.WriteLine(lambda);
            return lambda.Compile().Invoke();
        }

        static T GetPropertyValue<T>(Property<T> property) where T : struct
        {
            // p=>p.Value表示将整个Property当作参数传入
            var p = Expression.Parameter(property.GetType(), "p");
            //将参数传递进来 p.Value
            var value = Expression.Property(p, nameof(property.Value));
            //body-->lambda体(p.Value),p-->参数(p)
            var lambda = Expression.Lambda<Func<Property<T>, T>>(value, p);
            Console.WriteLine(lambda);
            return lambda.Compile().Invoke(property);
        }

        #endregion
    }
}