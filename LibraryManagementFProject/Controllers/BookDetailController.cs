using LibraryManagementFProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementFProject.Controllers
{
    public class BookDetailController : Controller
    {
        private readonly IBookDetailRepository _repo;


        public BookDetailController(IBookDetailRepository repo)
        {
            this._repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["BookTitleSortParam"] = string.IsNullOrEmpty(sortOrder) ? "BookTitle_desc" : "";
            ViewData["AuthorIDSortParam"] = sortOrder == "AuthorID" ? "AuthorID_desc" : "AuthorID";
            ViewData["FirstNameSortParam"] = sortOrder == "FirstName" ? "FirstName_desc" : "FirstName";
            ViewData["LastNameSortParam"] = sortOrder == "LastName" ? "LastName_desc" : "LastName";
            ViewData["ISBNCodeSortParam"] = sortOrder == "ISBNCode" ? "ISBNCode_desc" : "ISBN_Code";
            ViewData["PublicationYearSortParam"] = sortOrder == "PublicationYear" ? "PublicationYear_desc" : "Publication_year";
            
            ViewData["CurrentFilter"] = searchString;
          
            var books = _repo.GetAllBookDetails();

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Book_Title.Contains(searchString));
            }

            books = sortOrder switch
            {
                "ID" => books.OrderBy(s => s.AuthorID),
                "AuthorID_desc" => books.OrderByDescending(s => s.AuthorID),
                "BookTitle" => books.OrderBy(s => s.Book_Title),
                "BookTitle_desc" => books.OrderByDescending(s => s.Book_Title),
                "FirstName" => books.OrderBy(s => s.FirstName),
                "FirstName_desc" => books.OrderByDescending(s => s.FirstName),
                "LastName" => books.OrderBy(s => s.LastName),
                "LastName_desc" => books.OrderByDescending(s => s.LastName),
                "ISBNCode" => books.OrderBy(s => s.ISBN_Code),
                "ISBNCode_desc" => books.OrderByDescending(s => s.ISBN_Code),
                "Pulication" => books.OrderBy(s => s.Publication_year),
                "PublicationYear_desc" => books.OrderByDescending(s => s.Publication_year),
                "" => books.OrderBy(s => s.Book_Title),
                _ => books.OrderBy(s => s.Book_Title)
            };
            return View(books);
        }
        public IActionResult ViewBookDetail(int id)
        {
            var books = _repo.GetBookDetail(id);
            
            return View(books);
        }
        public IActionResult UpdateBookDetail(int id)
        {
            BookDetails book = _repo.GetBookDetail(id);

            if (book == null)
            {
                return View("BookNotFound");
            }

            return View(book);
        }
        public IActionResult UpdateBookDetailToDatabase(BookDetails book)
        {
            _repo.UpdateBookDetail(book);

            return RedirectToAction("ViewBookDetail", new { id = book.AuthorID });
        }
        public IActionResult InsertBookDetail()
        {
            var book = new BookDetails();

            return View(book);
        }
        public IActionResult InsertBookToDatabase(BookDetails bookToInsert)
        {
                _repo.InsertBookDetail(bookToInsert);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteBookDetail(BookDetails book)
        {
            _repo.DeleteBookDetail(book);

            return RedirectToAction("Index");
        }



    }
}
