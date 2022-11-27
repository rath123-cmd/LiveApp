using LiveApp.Models;
using LiveApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Controllers
{
    public class BookController : Controller
    {
        public BookRepository _bookRepository { get; set; }
        public BookController()
        {
            _bookRepository = new BookRepository();
        }

        public ViewResult GetAllBooks()
        {
            var list = _bookRepository.GetAllBooks();
            return View(list);
        }

        public ViewResult GetBookById(int id)
        {
            return View(_bookRepository.GetBookById(id));
        }

        public ViewResult SearchBook(string authorName)
        {
            //var list = _bookRepository.SearchBook(authorName);
            return View();
        }
    }
}
