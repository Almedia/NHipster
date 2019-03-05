using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Hipster.Streaming;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace Hipster.Api
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            //Consume kısmı mutlaka burda olmali
            //kilit noktalardan bir tanesi topic bazında  mesajları gruplayalip gerekli command'lari alabiliyor olmamız gerekiyor


            try
            {
                Log.Information("Starting web host");

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                // Log.CloseAndFlush();
            }
            CreateWebHostBuilder(args).Build().Run();
        }
        ///Startup.cs de tetiklemek istediğimiz custom class'lar için service configurasyonunu burda ya
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.UseUrls("http://localhost:8000")
                // .ConfigureServices(serviceCollection =>
                // {
                //     serviceCollection.AddSingleton<IMessageConsumer, MessageConsumer>();
                // })
                .UseSerilog();

    }
}
