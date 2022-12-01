using LiveApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        public BookRepository _bookRepository { get; }
        public TopBooksViewComponent(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            return View(await _bookRepository.GetTopBookAsync(count));
        }
    }
}
