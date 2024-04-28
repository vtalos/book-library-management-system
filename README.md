# Book Library Management System

This repository contains a simple book library management system implemented in C#. It allows users to perform CRUD operations (Create, Read, Update, Delete) on a collection of books via a console-based interface.

## Project Structure

The repository is organized into the following directories:

- `.github/workflows`: Contains GitHub Actions workflow files for continuous integration. 
  - `dotnet.yml`: Workflow for building and testing the project using .NET SDK.
  - `main.yml`: Workflow file for building and pushing a Docker image to Docker Hub.

- `App.Tests`: Contains unit tests for the application.
  - `App.Tests.csproj`: Project file for the unit tests.
  - `BookRepositoryTests.cs`: Unit tests for the BookRepository class.
  - `BookTests.cs`: Unit tests for the Book class.
  - `ProgramTests.cs`: Unit tests for the Program class.

- `App`: Contains the source code for the application.
  - `Book.cs`: Class definition for the Book entity.
  - `BookRepository.cs`: Class definition for the BookRepository, which manages the collection of books.
  - `Dockerfile`: Dockerfile for building a Docker image of the application.
  - `DotNet.Docker.csproj`: Project file for the application.
  - `Program.cs`: Main entry point of the application.

- `.gitignore`: Specifies intentionally untracked files to ignore.
- `README.md`: This file, providing an overview of the project and its structure.

## Usage

To run the application, simply execute the `Program.cs` file using a C# compiler or IDE that supports C# development. The application will prompt you with a menu to interact with the book library.

## Testing

Unit tests for the application are located in the `App.Tests` directory. To run the tests, use a test runner or execute the tests using the .NET CLI.

## Contributing

Contributions to this project are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or create a pull request.
