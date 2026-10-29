using SQLite;

namespace BookSearchApp.Models
{
    public class MyData
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [NotNull, MaxLength(100)]
        public string Title { get; set; }

        [NotNull, MaxLength(100)]
        public string Author { get; set; }

        [NotNull, MaxLength(50)]
        public string Genre { get; set; }

        [NotNull, MaxLength(4)]
        public string Year { get; set; }

        [NotNull]
        public int PageCount { get; set; }
    }
}