using System;

/// <summary>
/// Represents the main program class for managing the book library.
/// </summary>
public class Program
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
        BookRepository bookRepository = new BookRepository();

        int id; // Variable to store book ID

        while (true)
        {
            // Display menu options
            Console.WriteLine("Book Library Menu:");
            Console.WriteLine("1. Show Book List");
            Console.WriteLine("2. Search for a Book");
            Console.WriteLine("3. Add a New Book");
            Console.WriteLine("4. Delete a Book by ID");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            string? choice = Console.ReadLine(); // Read user choice

            // Process user choice
            switch (choice)
            {
                case "1":
                    Console.WriteLine();
                    ShowBookList(bookRepository);
                    break;

                case "2":
                    Console.WriteLine();
                    Console.Write("Enter the ID of the book to search: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        SearchForBook(bookRepository, id);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid integer.");
                    }
                    break;

                case "3":
                    Console.WriteLine();
                    Console.Write("Enter the title of the new book: ");
                    string? title = Console.ReadLine();
                    Console.Write("Enter the author of the new book: ");
                    string? author = Console.ReadLine();
                    Console.Write("Enter the genre of the new book: ");
                    string? genre = Console.ReadLine();
                    Console.Write("Enter the ISBN of the new book: ");
                    string? isbn = Console.ReadLine();
                    AddNewBook(bookRepository, title, author, genre, isbn);
                    break;

                case "4":
                    Console.WriteLine();
                    Console.Write("Enter the ID of the book to delete: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        DeleteBookById(bookRepository, id);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid integer.");
                    }
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

    /// <summary>
    /// Displays the list of all books in the repository.
    /// </summary>
    /// <param name="bookRepository">The book repository.</param>
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

    /// <summary>
    /// Searches for a book by its ID and displays its information if found.
    /// </summary>
    /// <param name="bookRepository">The book repository.</param>
    /// <param name="id">The ID of the book to search for.</param>
    public static void SearchForBook(BookRepository bookRepository, int id)
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

    /// <summary>
    /// Adds a new book to the repository.
    /// </summary>
    /// <param name="bookRepository">The book repository.</param>
    /// <param name="title">The title of the new book.</param>
    /// <param name="author">The author of the new book.</param>
    /// <param name="genre">The genre of the new book.</param>
    /// <param name="isbn">The ISBN of the new book.</param>
    public static void AddNewBook(BookRepository bookRepository, string? title, string? author, string? genre, string? isbn)
    {
        if (title == null || author == null || genre == null || isbn == null)
        {
            Console.WriteLine("Error: Title, author, genre, and ISBN must not be null.");
            return;
        }

        Book newBook = new Book { Title = title, Author = author, Genre = genre, ISBN = isbn };
        bookRepository.AddBook(newBook);
        Console.WriteLine("New book added successfully.");
    }

    /// <summary>
    /// Deletes a book from the repository by its ID.
    /// </summary>
    /// <param name="bookRepository">The book repository.</param>
    /// <param name="id">The ID of the book to delete.</param>
    public static void DeleteBookById(BookRepository bookRepository, int id)
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
}