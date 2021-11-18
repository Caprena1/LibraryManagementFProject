using LibraryManagementFProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementFProject
{
    public interface IBookDetailRepository
    {
        public IEnumerable<BookDetails> GetAllBookDetails();

        public BookDetails GetBookDetail(int id);
        public void UpdateBookDetail(BookDetails book);
        public void InsertBookDetail(BookDetails bookToInsert);
        public void DeleteBookDetail(BookDetails book);
        
        
    }
}


