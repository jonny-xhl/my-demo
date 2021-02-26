using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CancelationTokenDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 限制处理5秒
            var tokenSource1 = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var url = "https://www.baidu.com";
            // 1、测试没有CancellationToken情况
            await DownloadWebsite1(url, 100, tokenSource1.Token);
            Console.WriteLine("========================================分割线=================================================");
            // 2、测试有CancellationToken情况
            var tokenSource2 = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            // 另外一种方式制定终止时间
            //var tokenSource2 = new CancellationTokenSource();
            //tokenSource2.CancelAfter(TimeSpan.FromSeconds(5));
            await DownloadWebsite2(url, 100, tokenSource2.Token);

            #region LinkedTokenSource Test
            // 任意一个任务取消 则取消所有任务
            List<CancellationTokenSource> tokens = new List<CancellationTokenSource>
            {
                new CancellationTokenSource(TimeSpan.FromSeconds(2)),
                new CancellationTokenSource(TimeSpan.FromSeconds(4)),
                new CancellationTokenSource(TimeSpan.FromSeconds(6)),
                new CancellationTokenSource(TimeSpan.FromSeconds(8))
            };

            var compositeCancel = CancellationTokenSource.CreateLinkedTokenSource(tokens[0].Token, tokens[1].Token, tokens[2].Token, tokens[3].Token);
            TestLinkedTokenSource(compositeCancel.Token);
            // 手动测试终止任务，随机调用其中一个Cancel
            Random random = new Random();
            var randomIndex = random.Next(0, tokens.Count);
            tokens[randomIndex].Cancel();
            Console.WriteLine(string.Format("终止第{0}Token", randomIndex));
            #endregion

            Console.ReadLine();
        }

        static async Task DownloadWebsite1(string url, int downLoadTimes, CancellationToken cancellationToken)
        {
            while (downLoadTimes-- > 0)
            {
                using HttpClient httpClient = new HttpClient();
                // 当cancellationToken取消的时候GetStringAsync内部还会继续执行
                var html = await httpClient.GetStringAsync(new Uri(url));
                Console.WriteLine(html.Substring(0, 50));
                // 或者直接抛出异常
                //cancellationToken.ThrowIfCancellationRequested();
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("=====================DownloadWebsite1请求已终止！！！===========================");
                    break;
                }
            }
        }

        static async Task DownloadWebsite2(string url, int downLoadTimes, CancellationToken cancellationToken)
        {
            // 为了测试这样加try，实际开发中千万不要这么玩
            while (downLoadTimes-- > 0)
            {
                try
                {
                    using HttpClient httpClient = new HttpClient();
                    // 当cancellationToken取消的时候GetAsync内部就会终止,这里终止后会直接抛出异常
                    var htmlResponseMessage = await httpClient.GetAsync(new Uri(url), cancellationToken);
                    var html = await htmlResponseMessage.Content.ReadAsStringAsync();
                    Console.WriteLine(html.Substring(0, 50));
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("=====================DownloadWebsite2请求已终止！！！===========================");
                    break;
                }
            }
        }

        static Task TestLinkedTokenSource(CancellationToken cancellationToken)
        {
            int times = 1;
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine(times++);
            }
            Console.WriteLine("===========================外部终止===========================");
            return Task.CompletedTask;
        }
    }
}
