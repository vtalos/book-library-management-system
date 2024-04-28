using System;
using System.Collections.Generic;
using System.Linq;

public class BookRepository
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        book.Id = books.Count + 1; // Assign unique ID
        books.Add(book);
    }

    public Book GetBookById(int id)
    {
        return books.FirstOrDefault(b => b.Id == id);
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }

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

    public bool DeleteBook(int id)
    {
        int initialCount = books.Count;
        books.RemoveAll(b => b.Id == id);
        return books.Count < initialCount; // Returns true if a book was deleted
    }

}