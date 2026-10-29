using Microsoft.Maui.Controls;
using BookSearchApp.Views;

namespace BookSearchApp
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddItem), typeof(AddItem));
        }
    }
}