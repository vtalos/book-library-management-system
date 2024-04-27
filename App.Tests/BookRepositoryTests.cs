using Xunit;

public class BookRepositoryTests
{
    private BookRepository repository;

    public BookRepositoryTests()
    {
        repository = new BookRepository();
    }

    [Fact]
    public void AddBook_ShouldIncreaseCount()
    {
        // Arrange
        var initialCount = repository.GetAllBooks().Count;
        var bookToAdd = new Book { Title = "Test Book", Author = "Test Author", Genre = "Test Genre", ISBN = "Test ISBN" };

        // Act
        repository.AddBook(bookToAdd);

        // Assert
        Assert.Equal(initialCount + 1, repository.GetAllBooks().Count);
    }

    [Fact]
    public void GetBookById_ShouldReturnCorrectBook()
    {
        // Arrange
        var bookToAdd = new Book { Title = "Test Book", Author = "Test Author", Genre = "Test Genre", ISBN = "Test ISBN" };
        repository.AddBook(bookToAdd);

        // Act
        var retrievedBook = repository.GetBookById(1);

        // Assert
        Assert.NotNull(retrievedBook);
        Assert.Equal(bookToAdd.Title, retrievedBook.Title);
        Assert.Equal(bookToAdd.Author, retrievedBook.Author);
        Assert.Equal(bookToAdd.Genre, retrievedBook.Genre);
        Assert.Equal(bookToAdd.ISBN, retrievedBook.ISBN);
    }

    [Fact]
    public void UpdateBook_ShouldUpdateExistingBook()
    {
        // Arrange
        var bookToAdd = new Book { Title = "Test Book", Author = "Test Author", Genre = "Test Genre", ISBN = "Test ISBN" };
        repository.AddBook(bookToAdd);
        var updatedBook = new Book { Id = 1, Title = "Updated Test Book", Author = "Updated Test Author", Genre = "Updated Test Genre", ISBN = "Updated Test ISBN" };

        // Act
        repository.UpdateBook(updatedBook);
        var retrievedBook = repository.GetBookById(1);

        // Assert
        Assert.NotNull(retrievedBook);
        Assert.Equal(updatedBook.Title, retrievedBook.Title);
        Assert.Equal(updatedBook.Author, retrievedBook.Author);
        Assert.Equal(updatedBook.Genre, retrievedBook.Genre);
        Assert.Equal(updatedBook.ISBN, retrievedBook.ISBN);
    }

    [Fact]
    public void DeleteBook_ShouldRemoveBook()
    {
        // Arrange
        var bookToAdd = new Book { Title = "Test Book", Author = "Test Author", Genre = "Test Genre", ISBN = "Test ISBN" };
        repository.AddBook(bookToAdd);

        // Act
        var result = repository.DeleteBook(1);

        // Assert
        Assert.True(result);
        Assert.Empty(repository.GetAllBooks());
    }
}
