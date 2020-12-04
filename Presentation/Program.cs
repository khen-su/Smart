using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace KanbanBoard_Smart
{
    public class Program
    {
       
        public static async Task Main(string[] args)
        {
            
           var host =  CreateHostBuilder(args).Build();
            
           await host.StartAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
