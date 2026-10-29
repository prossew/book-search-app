using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Storage;
using BookSearchApp.Models;

namespace BookSearchApp;

public partial class App : Application
{
    public MyDatabase Database { get; private set; }

    public App()
    {
        AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            ShowError(e.ExceptionObject as Exception);
        TaskScheduler.UnobservedTaskException += (s, e) =>
        {
            ShowError(e.Exception);
            e.SetObserved();
        };

        try
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "books.db3");
            Database = new MyDatabase(dbPath);

            MainPage = new MainPage();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    public void ShowError(Exception ex)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            MainPage = new ContentPage
            {
                BackgroundColor = Colors.White,
                Content = new ScrollView
                {
                    Content = new VerticalStackLayout
                    {
                        Padding = 20,
                        Spacing = 12,
                        Children =
                        {
                            new Label { Text = "Ошибка", FontSize = 20, TextColor = Colors.Red },
                            new Label { Text = ex?.ToString() ?? "unknown", FontSize = 11, TextColor = Colors.Black }
                        }
                    }
                }
            };
        });
    }
}