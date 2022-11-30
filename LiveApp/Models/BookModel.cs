using LiveApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        public string Description { get; set; }
        [Required]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter the number of pages in the book.")]
        [Display(Name = "Total Pages")]
        public int? TotalPages { get; set; }
    }
}
