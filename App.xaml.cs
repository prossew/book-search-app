using Microsoft.Maui.Controls;

namespace BookSearchApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new MainPage();
    }
}