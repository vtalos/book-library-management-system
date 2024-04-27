using Xunit;

public class BookTests
{
    [Fact]
    public void Book_PropertiesShouldBeSetAndRetrievedCorrectly()
    {
        // Arrange
        var id = 1;
        var title = "Test Title";
        var author = "Test Author";
        var genre = "Test Genre";
        var isbn = "Test ISBN";

        // Act
        var book = new Book
        {
            Id = id,
            Title = title,
            Author = author,
            Genre = genre,
            ISBN = isbn
        };

        // Assert
        Assert.Equal(id, book.Id);
        Assert.Equal(title, book.Title);
        Assert.Equal(author, book.Author);
        Assert.Equal(genre, book.Genre);
        Assert.Equal(isbn, book.ISBN);
    }
}