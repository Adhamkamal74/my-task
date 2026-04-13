namespace LibrarySystem
{
    public static class BookFileHandler
    {
        private const string FilePath = "books.txt";

        public static void SaveBooks(Book[] books)
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (Book book in books)
                {
                    writer.WriteLine(book.ToString());
                }
            }
            Console.WriteLine($"Books saved to '{FilePath}' successfully.");
        }

        public static Book[] LoadBooks()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("No saved books file found.");
                return Array.Empty<Book>();
            }

            string[] lines = File.ReadAllLines(FilePath);
            List<Book> books = new List<Book>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 5)
                {
                    int id = int.Parse(parts[0]);
                    string title = parts[1];
                    string author = parts[2];
                    BookCategory category = (BookCategory)Enum.Parse(typeof(BookCategory), parts[3]);
                    bool isAvailable = bool.Parse(parts[4]);

                    books.Add(new Book(id, title, author, category, isAvailable));
                }
            }

            Console.WriteLine($"Loaded {books.Count} books from '{FilePath}'.");
            return books.ToArray();
        }
    }
}
