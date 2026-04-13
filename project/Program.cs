using LibrarySystem;

// Initialize array of 15 books
Book[] books = new Book[]
{
    new Book(1, "The Great Gatsby",         "F. Scott Fitzgerald", BookCategory.math,    true),
    new Book(2, "A Brief History of Time",  "Stephen Hawking",     BookCategory.Science,    true),
    new Book(3, "Sapiens",                  "Yuval Noah Harari",   BookCategory.History,    false),
    new Book(4, "The Alchemist",            "Paulo Coelho",        BookCategory.math,    true),
    new Book(5, "The Holy Quran",           "Allah",               BookCategory.physics,   true),
    new Book(6, "Clean Code",               "Robert C. Martin",    BookCategory.probapility, false),
    new Book(7, "1984",                     "George Orwell",       BookCategory.math,    true),
    new Book(8, "The Selfish Gene",         "Richard Dawkins",     BookCategory.Science,    true),
    new Book(9, "World War II History",     "Anthony Beevor",      BookCategory.History,    false),
    new Book(10,"The Power of Now",         "Eckhart Tolle",       BookCategory.physics,   true),
    new Book(11,"The Pragmatic Programmer", "Andrew Hunt",         BookCategory.probapility, true),
    new Book(12,"To Kill a Mockingbird",    "Harper Lee",          BookCategory.math,    false),
    new Book(13,"Cosmos",                   "Carl Sagan",          BookCategory.Science,    true),
    new Book(14,"Guns Germs and Steel",     "Jared Diamond",       BookCategory.History,    true),
    new Book(15,"Design Patterns",          "Gang of Four",        BookCategory.probapility, false),
};

bool running = true;

while (running)
{
    Console.WriteLine("\n===== Library System =====");
    Console.WriteLine("1. Display All Books");
    Console.WriteLine("2. Search by Title");
    Console.WriteLine("3. Search by Author");
    Console.WriteLine("4. Search by Category");
    Console.WriteLine("5. Update Book Status");
    Console.WriteLine("6. Save Books to File");
    Console.WriteLine("7. Load Books from File");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");

    string input = Console.ReadLine() ?? "0";

    switch (input)
    {
        case "1":
            Console.WriteLine("\n--- All Books ---");
            foreach (Book book in books)
                book.DisplayInfo();
            break;

        case "2":
            Console.Write("Enter title to search: ");
            string titleQuery = Console.ReadLine() ?? "";
            bool titleFound = false;
            foreach (Book book in books)
            {
                if (book.Title.Contains(titleQuery, StringComparison.OrdinalIgnoreCase))
                {
                    book.DisplayInfo();
                    titleFound = true;
                }
            }
            if (!titleFound)
                Console.WriteLine("No books found with that title.");
            break;

        case "3":
            Console.Write("Enter author to search: ");
            string authorQuery = Console.ReadLine() ?? "";
            bool authorFound = false;
            foreach (Book book in books)
            {
                if (book.Author.Contains(authorQuery, StringComparison.OrdinalIgnoreCase))
                {
                    book.DisplayInfo();
                    authorFound = true;
                }
            }
            if (!authorFound)
                Console.WriteLine("No books found for that author.");
            break;

        case "4":
            Console.WriteLine("Categories: Fiction, Science, History, Religion, Technology, Other");
            Console.Write("Enter category: ");
            string catInput = Console.ReadLine() ?? "";
            if (Enum.TryParse<BookCategory>(catInput, true, out BookCategory selectedCategory))
            {
                bool catFound = false;
                foreach (Book book in books)
                {
                    if (book.Category == selectedCategory)
                    {
                        book.DisplayInfo();
                        catFound = true;
                    }
                }
                if (!catFound)
                    Console.WriteLine("No books found in that category.");
            }
            else
            {
                Console.WriteLine("Invalid category.");
            }
            break;

        case "5":
            Console.Write("Enter book ID to update status: ");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                bool found = false;
                foreach (Book book in books)
                {
                    if (book.ID == bookId)
                    {
                        Console.Write("Set available? (true/false): ");
                        if (bool.TryParse(Console.ReadLine(), out bool newStatus))
                            book.UpdateStatus(newStatus);
                        else
                            Console.WriteLine("Invalid input.");
                        found = true;
                        break;
                    }
                }
                if (!found)
                    Console.WriteLine("Book not found.");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            break;

        case "6":
            BookFileHandler.SaveBooks(books);
            break;

        case "7":
            Book[] loaded = BookFileHandler.LoadBooks();
            if (loaded.Length > 0)
                books = loaded;
            break;

        case "0":
            running = false;
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid option, try again.");
            break;
    }
}
