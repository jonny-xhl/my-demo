using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace HostConsoleDemo
{
    public class AppService : IAppService, IHostedService
    {
        private IDisposable _scheduler;

        private readonly HelloOptions _helloOptions;
        private readonly IHostApplicationLifetime _lifetime;
        public AppService(IOptionsSnapshot<HelloOptions> options,
            IHostApplicationLifetime lifetime)
        {
            _helloOptions = options.Value;
            _lifetime = lifetime;
            _lifetime.ApplicationStarted.Register(() =>
            {
                Console.WriteLine($"[{DateTimeOffset.Now}]");
                Console.WriteLine("ApplicationStarted");
            });
            _lifetime.ApplicationStopping.Register(() =>
            {
                Console.WriteLine($"[{DateTimeOffset.Now}]");
                Console.WriteLine("ApplicationStopping");
            });
            _lifetime.ApplicationStopped.Register(() =>
            {
                Console.WriteLine($"[{DateTimeOffset.Now}]");
                Console.WriteLine("ApplicationStopped");
            });
        }

        public async Task SayHello()
        {
            await Task.Run((() => Console.WriteLine(_helloOptions.SayStr)));
        }

        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = new Timer(Callback, null, TimeSpan.FromSeconds(_helloOptions.Interval), TimeSpan.FromSeconds(_helloOptions.Interval));
            return Task.CompletedTask;
        }

        private async void Callback(object state)
        {
            Console.WriteLine($"[{DateTimeOffset.Now}]");
            await SayHello();
        }

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            _scheduler?.Dispose();
            return Task.CompletedTask;
        }
    }
}