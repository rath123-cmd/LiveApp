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
        public IBookRepository _bookRepository { get; }
        public TopBooksViewComponent(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            return View(await _bookRepository.GetTopBookAsync(count));
        }
    }
}
