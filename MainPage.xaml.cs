using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace BookSearchApp
{
    public partial class App : Application
    {
        public App()
        {
            try
            {
                InitializeComponent();
                MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                MainPage = new ContentPage
                {
                    Content = new ScrollView
                    {
                        Content = new Label
                        {
                            Text = ex.ToString(),
                            TextColor = Colors.Red,
                            Margin = 20
                        }
                    }
                };
            }
        }
    }
}