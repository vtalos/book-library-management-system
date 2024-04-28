using System;


public class Program
{
    public static void Main(string[] args)
    {
        BookRepository bookRepository = new BookRepository();

        while (true)
        {
            Console.WriteLine("Book Library Menu:");
            Console.WriteLine("1. Show Book List");
            Console.WriteLine("2. Search for a Book");
            Console.WriteLine("3. Add a New Book");
            Console.WriteLine("4. Delete a Book by ID");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine();
                    ShowBookList(bookRepository);
                    break;
                case "2":
                    Console.WriteLine();
                    SearchForBook(bookRepository);
                    break;
                case "3":
                    Console.WriteLine();
                    AddNewBook(bookRepository);
                    break;
                case "4":
                    Console.WriteLine();
                    DeleteBookById(bookRepository);
                    break;
                case "5":
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine(); // Add a blank line for readability
        }
    }

    public static void ShowBookList(BookRepository bookRepository)
    {
        var books = bookRepository.GetAllBooks();
        if (books.Count == 0)
        {
            Console.WriteLine("The book list is empty.");
            return;
        }

        Console.WriteLine("Book List:");
        foreach (var book in books)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, ISBN: {book.ISBN}");
        }
    }

    public static void SearchForBook(BookRepository bookRepository)
    {
        Console.Write("Enter the ID of the book to search: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var book = bookRepository.GetBookById(id);
            if (book != null)
            {
                Console.WriteLine($"Book found: Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}, ISBN: {book.ISBN}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a valid integer.");
        }
    }

    public static void AddNewBook(BookRepository bookRepository)
    {
        Console.Write("Enter the title of the new book: ");
        string title = Console.ReadLine();
        Console.Write("Enter the author of the new book: ");
        string author = Console.ReadLine();
        Console.Write("Enter the genre of the new book: ");
        string genre = Console.ReadLine();
        Console.Write("Enter the ISBN of the new book: ");
        string isbn = Console.ReadLine();

        Book newBook = new Book { Title = title, Author = author, Genre = genre, ISBN = isbn };
        bookRepository.AddBook(newBook);
        Console.WriteLine("New book added successfully.");
    }

    public static void DeleteBookById(BookRepository bookRepository)
    {
        Console.Write("Enter the ID of the book to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            bool deleted = bookRepository.DeleteBook(id);
            if (deleted)
            {
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a valid integer.");
        }
    }
}

