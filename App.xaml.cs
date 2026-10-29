using System;
using System.IO;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using BookSearchApp.Models;

namespace BookSearchApp;

public partial class App : Application
{
    // Единый экземпляр базы данных на всё приложение (избегаем múltiples подключений к одному файлу).
    public MyDatabase Database { get; private set; }

    public App()
    {
        try
        {
            InitializeComponent();

            // Путь к БД строго через FileSystem.AppDataDirectory (MAUI-способ),
            // а не через Environment.SpecialFolder или относительные пути.
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "books.db3");
            Database = new MyDatabase(dbPath);

            MainPage = new MainPage();
        }
        catch (Exception ex)
        {
            // Если при инициализации произошла ошибка — не молча умираем в белом экране,
            // а показываем страницу с текстом ошибки (и пишем в лог).
            System.Diagnostics.Debug.WriteLine($"[App] FATAL INIT ERROR: {ex}");

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Spacing = 12,
                    Children =
                    {
                        new Label
                        {
                            Text = "Ошибка запуска приложения",
                            FontSize = 20,
                            TextColor = Colors.Red,
                            HorizontalTextAlignment = TextAlignment.Center
                        },
                        new Label
                        {
                            Text = ex.Message,
                            FontSize = 14,
                            TextColor = Colors.Gray,
                            HorizontalTextAlignment = TextAlignment.Center
                        },
                        new Label
                        {
                            Text = ex.StackTrace,
                            FontSize = 10,
                            TextColor = Colors.Gray,
                            HorizontalTextAlignment = TextAlignment.Center,
                            LineBreakMode = LineBreakMode.WordWrap
                        }
                    }
                }
            };
        }
    }
}