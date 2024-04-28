using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a repository for managing books.
/// </summary>
public class BookRepository
{
    private List<Book> books = new List<Book>(); // Collection to store books

    /// <summary>
    /// Adds a book to the repository.
    /// </summary>
    /// <param name="book">The book to be added.</param>
    public void AddBook(Book book)
    {
        book.Id = books.Count + 1; // Assign unique ID
        books.Add(book);
    }

    /// <summary>
    /// Retrieves a book by its ID.
    /// </summary>
    /// <param name="id">The ID of the book to retrieve.</param>
    /// <returns>The book with the specified ID, or null if not found.</returns>
    public Book? GetBookById(int id)
    {
        return books.FirstOrDefault(b => b.Id == id);
    }

    /// <summary>
    /// Retrieves all books in the repository.
    /// </summary>
    /// <returns>A list of all books in the repository.</returns>
    public List<Book> GetAllBooks()
    {
        return books;
    }

    /// <summary>
    /// Updates information of an existing book.
    /// </summary>
    /// <param name="book">The updated book information.</param>
    public void UpdateBook(Book book)
    {
        var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.ISBN = book.ISBN;
        }
    }

    /// <summary>
    /// Deletes a book from the repository by its ID.
    /// </summary>
    /// <param name="id">The ID of the book to delete.</param>
    /// <returns>True if the book was successfully deleted; otherwise, false.</returns>
    public bool DeleteBook(int id)
    {
        int initialCount = books.Count;
        books.RemoveAll(b => b.Id == id);
        return books.Count < initialCount; // Returns true if a book was deleted
    }
}