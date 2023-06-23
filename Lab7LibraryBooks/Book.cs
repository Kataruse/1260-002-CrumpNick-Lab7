//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:		Lab7 - Library Books
//	File Name:		Book.cs
//	Description:	Provides a Book class to represent a Book with its title, author, and price.
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
/// Provides a Book class to represent a Book with its title, author, and price.
/// </summary>
public class Book
{
    public string Title;
    public string Author;
    public double Price;

    /// <summary>
    /// Default constructor: Initializes a new instance 
    /// 	of the Book class using default values
    /// </summary>
    public Book()
    {
        this.Title = "no title";
        this.Author = "no author";
        this.Price = 0.0;
    }

    /// <summary>
    /// Parameterized constructor: Initializes a new instance 
    /// 	of the Book class using values specified in the parameters
    /// </summary>
    /// <param name="title">Book title</param>
    /// <param name="author">Book author</param>
    /// <param name="price">Book price</param>
    public Book(string title, string author, double price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    /// <summary>
    /// Copy constructor: Initializes a new instance 
    /// 	of the Book class using a book object specified in the parameters
    /// </summary>
    /// <param name="b">An existing book object</param>
    public Book(Book b)
    {
        this.Title = b.Title;
        this.Author = b.Author;
        this.Price = b.Price;
    }

    /// <summary>
    /// Format the book information for possible display
    /// </summary>
    /// <returns>formatted string containing book information</returns>
    public override string ToString()
    {
        string str =  $"\nTitle:  {Title}";
               str += $"\nAuthor: {Author}";
               str += $"\nPrice:  ${Price:#,###.#0}";

        return str;
    }


}
