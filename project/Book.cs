namespace LibrarySystem
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookCategory Category { get; set; }
        public bool IsAvailable { get; set; }

        public Book(int id, string title, string author, BookCategory category, bool isAvailable = true)
        {
            ID = id;
            Title = title;
            Author = author;
            Category = category;
            IsAvailable = isAvailable;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Status: {(IsAvailable ? "Available" : "Not Available")}");
            Console.WriteLine(new string('-', 40));
        }

        public void UpdateStatus(bool isAvailable)
        {
            IsAvailable = isAvailable;
            Console.WriteLine($"Book '{Title}' status updated to: {(IsAvailable ? "Available" : "Not Available")}");
        }

        public override string ToString()
        {
            return $"{ID},{Title},{Author},{Category},{IsAvailable}";
        }
    }
}
