using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace estore.web
{
    public class Program
    {
        /// <summary>
        /// Starting point of the application
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseIISIntegration()
                .Build();
    }
}
