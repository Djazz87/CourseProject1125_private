using Avalonia;
using System;
using CourseProject1125.DB;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CourseProject1125;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args) // Добавили args для порядка
            // --- ДОБАВЬ ЭТОТ БЛОК ---
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders(); // Удаляет EventLog, который не работает на Linux
                logging.AddConsole();    // Оставляет вывод в консоль
            })
            // ------------------------
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true)
                    .AddEnvironmentVariables();
            })
            .ConfigureServices((c, s) =>
            {
                // Тут твоя настройка БД
                // s.Configure<Connection>(c.Configuration.GetSection("DataBaseConnection"));
            }).Build();

        BuildAvaloniaApp(host.Services)
            .StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp(IServiceProvider hostServices)
        => AppBuilder.Configure(() => new App(hostServices))
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}