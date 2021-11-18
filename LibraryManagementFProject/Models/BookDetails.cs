using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementFProject.Models
{
    public class BookDetails
    {

        public BookDetails()
        {
        }

        public int AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ISBN_Code { get; set; }
        public string Book_Title { get; set; }
        public int Publication_year { get; set; }
        public string Date_checkedout { get; set; }
        public string Date_returned { get; set; }
        //public string Image_pathLocation { get; set; }
    
    }
}
