using System;
using Microsoft.Maui.Controls;
using BookSearchApp.Views;

namespace BookSearchApp
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            try
            {
                InitializeComponent();
                Routing.RegisterRoute(nameof(AddItem), typeof(AddItem));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[MainPage] INIT ERROR: {ex}");
                throw;
            }
        }
    }
}