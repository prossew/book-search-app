using Microsoft.Maui.Controls;

namespace BookSearchApp
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddItem), typeof(Views.AddItem));
        }
    }
}