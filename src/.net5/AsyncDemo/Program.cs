using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            #region yield IAsyncEnumerable
            {
                Console.WriteLine("======SyncGetPeoplesByList======");
                foreach (var people in SyncGetPeoplesByYield())
                {
                    Console.WriteLine(people);
                }
                Console.WriteLine("======AsyncGetPeoplesByYield======");
                await foreach (var people in AsyncGetPeoplesByYield())
                {
                    Console.WriteLine(people);
                }
            }
            #endregion
            #region WhenAll WhenAny
            var task1 = File.ReadAllTextAsync(@"E:\temp\logs.txt");
            var task2 = File.ReadAllTextAsync(@"E:\temp\2020-05-11.txt");
            var task3 = File.ReadAllTextAsync(@"E:\temp\2020-06-17.txt");
            var task4 = File.ReadAllTextAsync(@"E:\temp\HttpService-log.txt");
            // 等待所有任务完成
            var all = await Task.WhenAll(task1, task2, task3, task4).ConfigureAwait(false);
            Console.WriteLine("{0};{1};{2};{3}", all[0], all[1], all[2], all[3]);

            //var any = await Task.WhenAny(task1, task2, task3, task4);
            //Console.WriteLine(any.Result);
            #endregion
            Console.ReadKey();
        }

        static IEnumerable<string> SyncGetPeoplesByYield()
        {
            yield return "Jonny";
            yield return "Honglin Xiang";
            yield return "James";
        }
        static IEnumerable<string> SyncGetPeoplesByList()
        {
            return new List<string>
            {
                "Jonny","Honglin Xiang","James"
            };
        }

        static async IAsyncEnumerable<string> AsyncGetPeoplesByYield()
        {
            yield return "Jonny";
            yield return "Honglin Xiang";
            yield return "James";
        }

    }
}
