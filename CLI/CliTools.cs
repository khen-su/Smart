using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.Hosting;

namespace CLI
{
    public class CliTools
    {
        private IHostEnvironment _env;

        CliTools(IHostEnvironment env)
        {
            _env = env;

        }
        static Task<int> Main(string[] args)
            => new HostBuilder()
                .RunCommandLineApplicationAsync<CliTools>(args);
            
    
        [Argument(0, Description = "message test")]
        private string Url { get; }

        private void OnExecute()
        {
            Console.WriteLine($"Starting on port {Url}, env = {_env.EnvironmentName}");
        }
    }
}