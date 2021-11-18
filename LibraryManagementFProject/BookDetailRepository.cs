using Dapper;
using LibraryManagementFProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryManagementFProject
{
    public class BookDetailRepository : IBookDetailRepository
    {
        private readonly IDbConnection _conn;

        public BookDetailRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<BookDetails> GetAllBookDetails()
        {
            return _conn.Query<BookDetails>("SELECT * FROM librarymanagement.book_details;");
        }
        public BookDetails GetBookDetail(int id)
        {
            return _conn.QuerySingle<BookDetails>("SELECT * FROM librarymanagement.book_details WHERE AUTHORID = @id",
                new { id = id });
        }

        public void UpdateBookDetail(BookDetails book)
        {
            _conn.Execute("UPDATE librarymanagement.book_details  SET Date_checkedout = @Date_checkedout, Date_returned = @Date_returned WHERE AuthorID = @id",
               new { Date_checkedout = book.Date_checkedout, Date_returned = book.Date_returned, id = book.AuthorID });
        }
        public void InsertBookDetail(BookDetails BookDetailToInsert)
        {
            _conn.Execute("INSERT INTO librarymanagement.book_details (" +
                "FirstName," +
                " LastName," +
                " ISBN_Code," +
                " Book_Title," +
                " Publication_year," +
                " Date_checkedout," +
                " Date_returned" +
                ")" +
                " VALUES (@FirstName, @LastName, @ISBN_Code, @Book_Title, @Publication_year, @Date_checkedout, @Date_returned);",
                new 
                {
                    FirstName = BookDetailToInsert.FirstName, 
                    LastName = BookDetailToInsert.LastName,
                    ISBN_Code = BookDetailToInsert.ISBN_Code,
                    Book_Title = BookDetailToInsert.Book_Title,  
                    Publication_year = BookDetailToInsert.Publication_year,
                    Date_checkedout = BookDetailToInsert.Date_checkedout,
                    Date_returned = BookDetailToInsert.Date_returned 
                });
        }
        
        public void DeleteBookDetail(BookDetails book)
        {
           
            _conn.Execute("DELETE FROM librarymanagement.book_details WHERE AuthorID = @id;",
                                       new { id = book.AuthorID });
        }


    }
}
