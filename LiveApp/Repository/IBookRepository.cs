using LiveApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveApp.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel book);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> GetSimilarBookAsync(int languageId, int bookId);
        Task<List<BookModel>> GetTopBookAsync(int count);
        List<BookModel> SearchBook(string author);
    }
}