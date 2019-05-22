using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace MantenedoresPerfilCliente.Presentation
{


    public class Program
  {
    public static IConfiguration Configuration { get;} = 
       new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
      .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
      .Build();

    public static void Main(string[] args)
    {
      Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();

        //.WriteTo.RollingFile("log-{Date}.txt")////Serilog.Debugging.SelfLog.Enable(msg =>
      //{
      //    Debug.Print(msg);
      //    Debugger.Break();
      //});

      try
      {
        Log.Information("Host starting...");

        BuildWebHost(args).Run();
      }
      catch (Exception ex)
      {
        Log.Fatal(ex, "Host terminated unexpectedly");
      }
      finally
      {
        Log.CloseAndFlush();
      }
    }

    public static IWebHost BuildWebHost(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>()
        .UseConfiguration(Configuration)
        .UseSerilog()
        .Build();
  }
}
