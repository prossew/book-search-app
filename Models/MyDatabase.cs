using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace BookSearchApp.Models
{
    public class MyDatabase
    {
        private readonly SQLiteConnection _database;

        public MyDatabase(string dbPath)
        {
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