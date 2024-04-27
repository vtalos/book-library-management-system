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

}
