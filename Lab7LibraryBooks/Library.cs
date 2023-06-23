//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Lab7 - Library Books
//	File Name:		Library.cs
//	Description:	Provides a Library class, which has a collection of Books.
//	Course:			CSCI 1260-002
//	Author:			Don Bailes, bailes@etsu.edu, Department of Computing, East Tennessee State University
//	Created:		Thursday, January 09, 2020
//  Modified:       06/23/22 by Erin Cook, cookel@etsu.edu convert from Java to C#
//                  03/23/23 by Katie Wilson, wilsonkl4@etsu.edu
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides a Library class, which has a collection of Books.
/// </summary>
public class Library
{
    private List<Book> Books;
    private bool HasChange;

    /// <summary>
    /// Default constructor: Initializes a new instance 
    /// 	of the Book class using default values
    /// </summary>
    public Library()
    {
        this.Books = new List<Book>();
        this.HasChange = false;
    }

    /// <summary>
    /// Return the number of Books in books collection
    /// </summary>
    /// <returns>return the number of Books in books</returns>
    public int GetNumBooks()
    {
        return Books.Count;
    }

    /// <summary>
    /// If n is valid, return nth Book in the library;
    ///     else throw exception
    /// </summary>
    /// <param name="n">the position of the book to be returned</param>
    /// <returns>the selected book</returns>
    /// <exception cref="Exception"></exception>
    public Book GetBook(int n)
    {
        if (n >= 0 && n < GetNumBooks())
            return Books[n];
        else
            throw new Exception($"There is no book number {n}" +
                $" in the library.");
    }

    /// <summary>
    /// Add a book to the library if it is not already
    ///     present; throw excetion if it is already
    /// </summary>
    /// <param name="b">Book to Add</param>
    /// <exception cref="Exception"></exception>
    public void AddBook(Book b)
    {
        foreach(Book book in Books)
        {
            if(book.Title == b.Title && book.Author == b.Author)
                throw new Exception($"Book '{b.Title}' by {b.Author} is already in the library");
        }

        Books.Add(b);
        HasChange = true;
    }

    /// <summary>
    /// Reset HasChange property to false
    /// </summary>
    public void ResetChangeFlag()
    {
        HasChange = false;
    }

    /// <summary>
    /// Delete the selected book from the library
    /// </summary>
    /// <param name="index">position of Book to be deleted</param>
    /// <exception cref="Exception"></exception>
    public void Delete(int index)
    {
        if((index >= 0) && (index < GetNumBooks()))
        {
            Books.RemoveAt(index);
            HasChange = true;
        }
        else
        {
            throw new Exception($"There is no book number {index}" +
                $" in the library.");
        }

    }

    /// <summary>
    /// Format the books in the library for display
    /// </summary>
    /// <returns>the formatted string</returns>
    public override string ToString()
    {
        string str = "";
        for(int n = 0; n < GetNumBooks(); n++)
        {
            str += $"\nBook {n + 1}. {Books[n]}\n";
        }
        return str;
    }
}
