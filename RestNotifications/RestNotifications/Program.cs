using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace RestNotifications
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HostBuilder();
            var times = new System.Threading.Timer(
                e => RestNotificationService.Notify(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(15));
            await builder.RunConsoleAsync();
        }
    }
}
