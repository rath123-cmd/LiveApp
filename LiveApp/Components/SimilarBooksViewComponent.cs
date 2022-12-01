using LiveApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Components
{
    public class SimilarBooksViewComponent : ViewComponent
    {
        public BookRepository _bookRepository { get; }
        public SimilarBooksViewComponent(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int languageId, int bookId)
        {
            return View(await _bookRepository.GetSimilarBookAsync(languageId, bookId));
        }
    }
}
