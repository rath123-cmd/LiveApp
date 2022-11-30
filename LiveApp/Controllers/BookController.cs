using LiveApp.Models;
using LiveApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Controllers
{
    public class BookController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        private BookRepository _bookRepository { get; set; }
        private LanguageRepository _languageRepository { get; set; }

        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            Title = "All Books";
            var list =await _bookRepository.GetAllBooks();
            return View(list);
        }

        [Route("book-details/{id:int:min(1)}", Name = "bookDetailsRoute")]
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
            int id = await _bookRepository.AddNewBook(bookModel);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            ViewBag.Languages = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            return View();
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
