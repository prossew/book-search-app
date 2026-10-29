using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

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
                throw;
            }
        }
    }
}