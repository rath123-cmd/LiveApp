using LiveApp.Data;
using LiveApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
       
        public async Task<int> AddNewBook(BookModel book)
        {
            var newBook = new Books {
                Author = book.Author,
                CreatedOn = DateTime.UtcNow,
                Description = book.Description,
                Name = book.Name,
                LanguageId = book.LanguageId,
                TotalPages = book.TotalPages.HasValue ? book.TotalPages.Value : 0
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                  .Select(book => new BookModel()
                  {
                      Author = book.Author,
                      Category = book.Category,
                      Description = book.Description,
                      Id = book.Id,
                      LanguageId = book.LanguageId,
                      Language = book.Language.Name,
                      Name = book.Name,
                      TotalPages = book.TotalPages,
                  }).ToListAsync();
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Name = book.Name,
                    TotalPages = book.TotalPages
                }).FirstOrDefaultAsync();
        }

        public List<BookModel> SearchBook(string author)
        {
            return null;
        }

        
    }
}
