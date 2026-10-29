using System;
using System.IO;
using Microsoft.Maui;
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
        try
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "books.db3");
            Database = new MyDatabase(dbPath);

            MainPage = new MainPage();
        }
        catch (Exception ex)
        {
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