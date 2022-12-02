using LiveApp.Models;
using LiveApp.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Controllers
{
    [Route("[action]")]
    public class BookController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        private IBookRepository _bookRepository { get; set; }
        private ILanguageRepository _languageRepository { get; set; }
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public BookController(IBookRepository bookRepository, 
            ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            Title = "All Books";
            var list =await _bookRepository.GetAllBooks();
            return View(list);
        }

        [Route("{id:int:min(1)}")]
        public async Task<ViewResult> GetBookById(int id)
        {
            Title ="Book Details";
            var data = await _bookRepository.GetBookById(id);
            //ViewBag.Book = _bookRepository.GetBookById(id);
            return View(data);
        }

        public ViewResult SearchBook(string authorName)
        {
            //var list = _bookRepository.SearchBook(authorName);
            return View();
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            Title = "Add New Book";

            ViewBag.Languages = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.Id = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            Title = "Add New Book";
            
            if (ModelState.IsValid)
            {
                if(bookModel.CoverPhoto != null)
                {
                    string folder = "Book/CoverPhotos/";
                    bookModel.CoverPhotoUrl = await UploadFile(folder, bookModel.CoverPhoto);
                }

                if (bookModel.GalleryFiles != null)
                {
                    string folder = "Book/Gallery/";
                    bookModel.Gallery = new List<GalleryModel>();
                    foreach (var file in bookModel.GalleryFiles)
                    {
                        bookModel.Gallery.Add(new GalleryModel() { 
                            Name = file.FileName,
                            Url = await UploadFile(folder, file)
                        });
                    }
                }

                if (bookModel.BookPdf != null)
                {
                    string folder = "Book/Pdf/";
                    bookModel.BookPdfUrl = await UploadFile(folder, bookModel.BookPdf);
                }

                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            ViewBag.Languages = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            return View();
        }

        private async Task<string> UploadFile(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        [Route("similarbooks")]
        [System.Web.Mvc.ChildActionOnly]
        public async Task<PartialViewResult> GetSimilarBooks()
        {
            Title = "Similar Books";
            var allBooks = await _bookRepository.GetAllBooks();
            return PartialView("GetSimilarBooks", allBooks);
        }

    }
}
