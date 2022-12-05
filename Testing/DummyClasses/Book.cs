namespace Testing
{
    public class Book
    {
        private string id;
        private string author;
        private string title;
        private string genre;
        private double price;
        private string date;
        private string description;

        public Book(string id, string author, string title, string genre, double price, string publish_date, string description)
        {
            this.id = id;
            this.author = author;
            this.title = title;
            this.genre = genre;
            this.price = price;
            this.date = publish_date;
            this.description = description;
        }

        public override string ToString()
        {
            return "<" + string.Join(", ", id, author, title, genre, price, date, description) + ">";
        }
    }
}
