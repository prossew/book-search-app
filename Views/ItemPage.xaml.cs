using System;
using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;
using BookSearchApp.Models;

namespace BookSearchApp.Views
{
    public partial class ItemPage : ContentPage
    {
        private readonly MyDatabase _database;
        private ObservableCollection<MyData> _books;

        public ItemPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "books.db3");
            _database = new MyDatabase(dbPath);

            _books = new ObservableCollection<MyData>();
            BooksListView.ItemsSource = _books;

            LoadBooks();
        }

        private void LoadBooks()
        {
            var books = _database.GetAllData();
            _books.Clear();
            foreach (var book in books)
            {
                _books.Add(book);
            }
        }

        private async void OnRefreshClicked(object sender, EventArgs e)
        {
            LoadBooks();
            StatusLabel.Text = "Список обновлён.";
            StatusLabel.TextColor = Colors.Green;
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTerm = e.NewTextValue?.Trim();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadBooks();
            }
            else
            {
                var filtered = _database.SearchBooks(searchTerm);
                _books.Clear();
                foreach (var book in filtered)
                {
                    _books.Add(book);
                }
            }
        }

        private void OnBookSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Выделение сохраняется, чтобы кнопка "Удалить" могла получить выбранную книгу
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var selectedBook = BooksListView.SelectedItem as MyData;

            if (selectedBook == null)
            {
                StatusLabel.Text = "Пожалуйста, выберите книгу для удаления.";
                StatusLabel.TextColor = Colors.Red;
                return;
            }

            bool confirm = await DisplayAlert("Подтверждение",
                $"Удалить книгу \"{selectedBook.Title}\"?",
                "Да", "Нет");

            if (confirm)
            {
                _database.DeleteBook(selectedBook.ID);
                _books.Remove(selectedBook);
                StatusLabel.Text = "Книга удалена.";
                StatusLabel.TextColor = Colors.Green;
            }
        }
    }
}