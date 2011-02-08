using SQLite;

namespace DatabaseDemo.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public string Title { get; set; }

        public string Contents { get; set; }
    }
}