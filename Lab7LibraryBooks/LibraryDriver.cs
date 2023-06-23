//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Lab7 - Library Books
//	File Name:		LibraryDriver.cs
//	Description:	Shows the functionality of the Library and Book classes, along with implementing file I/O.
//	Course:			CSCI 1260-002
//	Author:			Don Bailes, bailes@etsu.edu, Department of Computing, East Tennessee State University
//	Created:		Thursday, January 09, 2020
//  Modified:       06/23/22 by Erin Cook, cookel@etsu.edu convert from Java to C#
//                  03/23/23 by Katie Wilson, wilsonkl4@etsu.edu
//                  03/28/23 by Nicholas Crump, crumpna@etsu.edu
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

/// <summary>
/// Shows the functionality of the Library and Book classes, along with implementing file I/O.
/// </summary>
public class LibraryDriver
{
    private static Library lib = new Library();
    private static string fileName;                 // Save filename for later use

    /// <summary>
    /// Main method - fill library from input file; add books;
    ///     save library
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("     Welcome to the Library Manager\n" +
            "---------------------------------------\n\tby Nicholas Crump");
        InputFile();
        DisplayLibrary();
        AddBooks();

        Console.WriteLine("Thank you for using the Library Manager.");
    }

    /// <summary>
    /// Save the file back to its original position
    /// </summary>
    private static void SaveFile()
    {

        try
        {

            StreamWriter rwr = new StreamWriter($@"..\..\..\BookData\{fileName}");

            for(int i = 0; i < lib.GetNumBooks(); i++)
            {
                if (i < lib.GetNumBooks() - 1)
                {
                    if (lib.GetBook(i).Price % 1 == 0)
                    {
                        string price = Convert.ToString(lib.GetBook(i).Price) + ".0";
                        rwr.WriteLine(lib.GetBook(i).Title + "," + lib.GetBook(i).Author + "," + price);
                    }
                    else
                    {
                        rwr.WriteLine(lib.GetBook(i).Title + "," + lib.GetBook(i).Author + "," + lib.GetBook(i).Price);
                    }
                }
                else
                {
                    if (lib.GetBook(i).Price % 1 == 0)
                    {
                        string price = Convert.ToString(lib.GetBook(i).Price) + ".0";
                        rwr.Write(lib.GetBook(i).Title + "," + lib.GetBook(i).Author + "," + price);
                    }
                    else
                    {
                        rwr.Write(lib.GetBook(i).Title + "," + lib.GetBook(i).Author + "," + lib.GetBook(i).Price);
                    }
                }
            }

            rwr.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    /// <summary>
    /// Allow the user to try to add any number of books to the library; this
    ///     will result in an exception if one tries to add a book beyond the 
    ///     library size
    /// </summary>
    private static void AddBooks()
    {
        //Do not modify the line below
        int booksAdded = 0;
        string userInput = "";

        while (true)
        {
            Console.WriteLine("\nWould you like to add more books?");
            userInput = Console.ReadLine();
            if (userInput.ToLower() == "yes")
            {
                Console.WriteLine("\nEnter the book title.");
                string bookTitle = Console.ReadLine();
                Console.WriteLine("\nEnter the book author.");
                string bookAuthor = Console.ReadLine();
                double bookPrice = 0;

                try
                {
                    Console.WriteLine("\nEnter the book price.");
                    bookPrice = Convert.ToDouble(Console.ReadLine());

                    Book book = new Book(bookTitle, bookAuthor, bookPrice);
                    lib.AddBook(book);
                    booksAdded++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            else
            {
                break;
            }
        }


        //Do not modify the lines below
        if (booksAdded > 0)
        {
            if (booksAdded == 1)
                Console.WriteLine($"{booksAdded} book added");
            else
                Console.WriteLine($"{booksAdded} books added");
            DisplayLibrary();
            SaveFile();
        }

    }

    /// <summary>
    /// Get the filename from the user and try to open it; read
    ///     contents and build library; handle any exceptions 
    ///     that occur.
    /// </summary>
    private static void InputFile()
    {
        Console.WriteLine("Enter in a file");
        fileName = Console.ReadLine();
        
        try
        {
            StreamReader rdr = new StreamReader($@"..\..\..\BookData\{fileName}");

            while (rdr.Peek() != -1)
            {
                string nextLine = rdr.ReadLine();

                string[] bookData = nextLine.Split(",");

                Book book = new Book(bookData[0], bookData[1], Convert.ToDouble(bookData[2]));
                lib.AddBook(book);
           }

            rdr.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Display the current library contents
    /// </summary>
    private static void DisplayLibrary()
    {
        Console.WriteLine($"You should have {lib.GetNumBooks()}" +
            $" books in the library list.");
        Console.WriteLine($"\nLibrary Contents\n------------------\n" +
            $"{lib}\n------------------\n");
    }
}

