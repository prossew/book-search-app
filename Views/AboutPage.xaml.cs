using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace BookSearchApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[AboutPage] INIT ERROR: {ex}");

                Content = new VerticalStackLayout
                {
                    Padding = 20,
                    Spacing = 10,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label { Text = "Ошибка в AboutPage:", TextColor = Colors.Red, FontSize = 18 },
                        new Label { Text = ex.Message, TextColor = Colors.Black, FontSize = 14 },
                        new Label { Text = ex.StackTrace ?? "", TextColor = Colors.Gray, FontSize = 10 }
                    }
                };
            }
        }
    }
}