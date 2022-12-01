using LiveApp.Data;
using Microsoft.AspNetCore.Http;
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
        [Required]
        [Display(Name = "Book Cover Page")]
        public IFormFile CoverPhoto { get; set; }
        public string CoverPhotoUrl { get; set; }
        [Required]
        [Display(Name = "Book Gallery Photos")]
        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> Gallery { get; set; }
        [Required]
        [Display(Name = "Book Pdf form")]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }
    }
}
