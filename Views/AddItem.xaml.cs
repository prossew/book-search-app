using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using BookSearchApp.Models;

namespace BookSearchApp.Views
{
    public partial class AddItem : ContentPage
    {
        private readonly MyDatabase _database;

        public AddItem()
        {
            InitializeComponent();

            try
            {
                // Используем общий экземпляр БД из App, путь уже правильный (AppDataDirectory).
                var app = (App)Application.Current;
                _database = app.Database ?? throw new InvalidOperationException("База данных не инициализирована в App.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[AddItem] DATABASE ERROR: {ex}");
                StatusLabel.Text = $"Ошибка базы данных: {ex.Message}";
                StatusLabel.TextColor = Colors.Red;
                throw;
            }
        }

        private async void OnAddBookClicked(object sender, EventArgs e)
        {
            string title = TitleEntry?.Text?.Trim();
            string author = AuthorEntry?.Text?.Trim();
            string genre = GenreEntry?.Text?.Trim();
            string year = YearEntry?.Text?.Trim();
            string pageCountText = PageCountEntry?.Text?.Trim();

            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(genre) ||
                string.IsNullOrWhiteSpace(year) ||
                string.IsNullOrWhiteSpace(pageCountText))
            {
                StatusLabel.Text = "Пожалуйста, заполните все поля.";
                StatusLabel.TextColor = Colors.Red;
                return;
            }

            if (year.Length > 4)
            {
                StatusLabel.Text = "Год должен содержать не более 4 цифр.";
                StatusLabel.TextColor = Colors.Red;
                return;
            }

            if (!int.TryParse(pageCountText, out int pageCount))
            {
                StatusLabel.Text = "Количество страниц должно быть числом.";
                StatusLabel.TextColor = Colors.Red;
                return;
            }

            try
            {
                _database.AddBook(title, author, genre, year, pageCount);

                StatusLabel.Text = "Книга успешно добавлена!";
                StatusLabel.TextColor = Colors.Green;

                TitleEntry.Text = string.Empty;
                AuthorEntry.Text = string.Empty;
                GenreEntry.Text = string.Empty;
                YearEntry.Text = string.Empty;
                PageCountEntry.Text = string.Empty;
            }
            catch (Exception ex)
            {
                StatusLabel.Text = $"Ошибка: {ex.Message}";
                StatusLabel.TextColor = Colors.Red;
            }
        }
    }
}