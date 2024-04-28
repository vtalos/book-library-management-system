using System;
using System.IO;
using Xunit;

public class ProgramTests : IDisposable
{
    private StringWriter consoleOutput;
    private StringReader consoleInput;
    private BookRepository bookRepository;

    public ProgramTests()
    {
        consoleOutput = new StringWriter();
        consoleInput = new StringReader("");
        Console.SetOut(consoleOutput);
        Console.SetIn(consoleInput);
        bookRepository = new BookRepository();
    }

    public void Dispose()
    {
        consoleOutput.Dispose();
        consoleInput.Dispose();
    }

    [Fact]
    public void Main_ExitOption_ShouldPrintExitingMessage()
    {
        // Arrange
        string[] inputLines = { "5" };
        consoleInput = new StringReader(string.Join(Environment.NewLine, inputLines));
        Console.SetIn(consoleInput);

        // Act
        Program.Main(new string[] { });

        // Assert
        Assert.Contains("Exiting the program...", consoleOutput.ToString());
    }


    [Fact]
    public void ShowBookList_EmptyRepository_ShouldPrintEmptyMessage()
    {
        // Arrange
        var expectedOutput = "The book list is empty." + Environment.NewLine;

        // Act
        Program.ShowBookList(bookRepository);

        // Assert
        Assert.Equal(expectedOutput, consoleOutput.ToString());
    }

    [Fact]
    public void ShowBookList_WithBooks_ShouldPrintBookList()
    {
        // Arrange
        var books = new List<Book>
    {
        new Book { Id = 1, Title = "Book1", Author = "Author1", Genre = "Genre1", ISBN = "ISBN1" },
        new Book { Id = 2, Title = "Book2", Author = "Author2", Genre = "Genre2", ISBN = "ISBN2" }
    };
        var bookRepository = new BookRepository();
        
        for (int i = 0; i < books.Count; i++)
        {
            var book = books[i];
            bookRepository.AddBook(book);
        }

        var expectedOutput = "Book List:" + Environment.NewLine +
                             "ID: 1, Title: Book1, Author: Author1, Genre: Genre1, ISBN: ISBN1" + Environment.NewLine +
                             "ID: 2, Title: Book2, Author: Author2, Genre: Genre2, ISBN: ISBN2" + Environment.NewLine;
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        Program.ShowBookList(bookRepository);
        var printedOutput = consoleOutput.ToString();

        // Assert
        Assert.Equal(expectedOutput, printedOutput);
    }

    [Fact]
    public void SearchForBook_BookExists_ShouldPrintBookDetails()
    {
        // Arrange
        var books = new List<Book>
    {
        new Book { Id = 1, Title = "Book1", Author = "Author1", Genre = "Genre1", ISBN = "ISBN1" },
        new Book { Id = 2, Title = "Book2", Author = "Author2", Genre = "Genre2", ISBN = "ISBN2" }
    };
        var bookRepository = new BookRepository();

        for (int i = 0; i < books.Count; i++)
        {
            var book = books[i];
            bookRepository.AddBook(book);
        }

        var idToSearch = 1;
        var expectedOutput = "Book found: Title: Book1, Author: Author1, Genre: Genre1, ISBN: ISBN1" + Environment.NewLine;
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        Program.SearchForBook(bookRepository, idToSearch);
        var printedOutput = consoleOutput.ToString();

        // Assert
        Assert.Equal(expectedOutput, printedOutput);
    }

    [Fact]
    public void SearchForBook_BookDoesNotExist_ShouldPrintNotFoundMessage()
    {
        // Arrange
        var books = new List<Book>
    {
        new Book { Id = 1, Title = "Book1", Author = "Author1", Genre = "Genre1", ISBN = "ISBN1" },
        new Book { Id = 2, Title = "Book2", Author = "Author2", Genre = "Genre2", ISBN = "ISBN2" }
    };
        var bookRepository = new BookRepository();

        for (int i = 0; i < books.Count; i++)
        {
            var book = books[i];
            bookRepository.AddBook(book);
        }

        var idToSearch = 3;
        var expectedOutput = "Book not found." + Environment.NewLine;
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        Program.SearchForBook(bookRepository, idToSearch);
        var printedOutput = consoleOutput.ToString();

        // Assert
        Assert.Equal(expectedOutput, printedOutput);
    }

    [Fact]
    public void AddNewBook_ValidInput_ShouldPrintSuccessMessage()
    {
        // Arrange
        var bookRepository = new BookRepository();
        var title = "New Book";
        var author = "Author";
        var genre = "Fiction";
        var isbn = "1234567890";
        var expectedOutput = "New book added successfully." + Environment.NewLine;
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        Program.AddNewBook(bookRepository, title, author, genre, isbn);
        var printedOutput = consoleOutput.ToString();

        // Assert
        Assert.Equal(expectedOutput, printedOutput);
    }

    [Fact]
    public void DeleteBookById_ExistingBook_ShouldDeleteBookFromRepository()
    {
        // Arrange
        var books = new List<Book>
    {
        new Book { Id = 1, Title = "Book1", Author = "Author1", Genre = "Genre1", ISBN = "ISBN1" },
        new Book { Id = 2, Title = "Book2", Author = "Author2", Genre = "Genre2", ISBN = "ISBN2" }
    };
        var bookRepository = new BookRepository();

        for (int i = 0; i < books.Count; i++)
        {
            var book = books[i];
            bookRepository.AddBook(book);
        }

        var idToDelete = 1;

        // Act
        Program.DeleteBookById(bookRepository, idToDelete);

        // Assert
        Assert.DoesNotContain(bookRepository.GetAllBooks(), book => book.Id == idToDelete);
    }

    [Fact]
    public void DeleteBookById_ExistingBook_ShouldPrintSuccessMessage()
    {
        // Arrange
        var books = new List<Book>
    {
        new Book { Id = 1, Title = "Book1", Author = "Author1", Genre = "Genre1", ISBN = "ISBN1" },
        new Book { Id = 2, Title = "Book2", Author = "Author2", Genre = "Genre2", ISBN = "ISBN2" }
    };
        var bookRepository = new BookRepository();

        for (int i = 0; i < books.Count; i++)
        {
            var book = books[i];
            bookRepository.AddBook(book);
        }

        var idToDelete = 1;
        var expectedOutput = "Book deleted successfully." + Environment.NewLine;
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        Program.DeleteBookById(bookRepository, idToDelete);
        var printedOutput = consoleOutput.ToString();

        // Assert
        Assert.Equal(expectedOutput, printedOutput);
    }

    [Fact]
    public void DeleteBookById_NonExistingBook_ShouldNotDeleteAnyBookFromRepository()
    {
        // Arrange
        var books = new List<Book>
    {
        new Book { Id = 1, Title = "Book1", Author = "Author1", Genre = "Genre1", ISBN = "ISBN1" },
        new Book { Id = 2, Title = "Book2", Author = "Author2", Genre = "Genre2", ISBN = "ISBN2" }
    };
        var bookRepository = new BookRepository();

        for (int i = 0; i < books.Count; i++)
        {
            var book = books[i];
            bookRepository.AddBook(book);
        }

        var idToDelete = 3;

        // Act
        Program.DeleteBookById(bookRepository, idToDelete);

        // Assert
        Assert.Equal(2, bookRepository.GetAllBooks().Count);
    }

    [Fact]
    public void DeleteBookById_NonExistingBook_ShouldPrintNotFoundMessage()
    {
        // Arrange
        var books = new List<Book>
    {
        new Book { Id = 1, Title = "Book1", Author = "Author1", Genre = "Genre1", ISBN = "ISBN1" },
        new Book { Id = 2, Title = "Book2", Author = "Author2", Genre = "Genre2", ISBN = "ISBN2" }
    };
        var bookRepository = new BookRepository();

        for (int i = 0; i < books.Count; i++)
        {
            var book = books[i];
            bookRepository.AddBook(book);
        }

        var idToDelete = 3;
        var expectedOutput = "Book not found." + Environment.NewLine;
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);

        // Act
        Program.DeleteBookById(bookRepository, idToDelete);
        var printedOutput = consoleOutput.ToString();

        // Assert
        Assert.Equal(expectedOutput, printedOutput);
    }

}
