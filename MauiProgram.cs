using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using SQLitePCL;

namespace BookSearchApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        // ОБЯЗАТЕЛЬНО: инициализация нативной библиотеки SQLite для sqlite-net-pcl на Android.
        // Без этого первое обращение к БД упадёт с DllNotFoundException / SQLiteException — белый экран.
        Batteries_V2.Init();

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Логгирование (чтобы видеть ошибки в Device Log / Logcat)
        builder.Services.AddLogging(logging =>
        {
            logging.AddDebug();
#if DEBUG
            logging.SetMinimumLevel(LogLevel.Debug);
#else
            logging.SetMinimumLevel(LogLevel.Error);
#endif
        });

        return builder.Build();
    }
}