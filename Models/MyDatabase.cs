using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using SQLitePCL;

namespace BookSearchApp.Models
{
    public class MyDatabase
    {
        private readonly SQLiteConnection _database;

        // Двойная защита: гарантируем, что нативная SQLite инициализирована,
        // даже если MyDatabase создан до вызова Batteries_V2.Init() в MauiProgram.
        static MyDatabase()
        {
            Batteries_V2.Init();
        }

        public MyDatabase(string dbPath)
        {
            if (string.IsNullOrWhiteSpace(dbPath))
                throw new ArgumentException("Путь к базе данных не может быть пустым.", nameof(dbPath));

            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<MyData>();
        }

        public List<MyData> GetAllData()
        {
            return _database.Table<MyData>().ToList();
        }

        public List<MyData> SearchBooks(string searchTerm)
        {
            return _database.Table<MyData>()
                .Where(b => b.Title.Contains(searchTerm) ||
                            b.Author.Contains(searchTerm) ||
                            b.Genre.Contains(searchTerm))
                .ToList();
        }

        public int AddBook(string title, string author, string genre, string year, int pageCount)
        {
            var book = new MyData
            {
                Title = title,
                Author = author,
                Genre = genre,
                Year = year,
                PageCount = pageCount
            };
            return _database.Insert(book);
        }

        public int DeleteBook(int id)
        {
            return _database.Delete<MyData>(id);
        }
    }
}