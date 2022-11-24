using LiveApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string author)
        {
            return DataSource().Where(x => x.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>
            {
                new BookModel() { Id = 1, Author = "Rathin Karmakar", Name = "How to live a life" },
                new BookModel() { Id = 2, Author = "Tapendu Karmakar", Name = "Sea of life" },
                new BookModel() { Id = 3, Author = "Rathin Das", Name = "How to draw" },
                new BookModel() { Id = 4, Author = "Subendu Mondal", Name = "What is life" },
                new BookModel() { Id = 5, Author = "Smriti Das", Name = "Life is short" },
                new BookModel() { Id = 6, Author = "Suman Karmakar", Name = "Live yourself" },
                new BookModel() { Id = 7, Author = "Rathin Bhattacharya", Name = "Dont give up" },
                new BookModel() { Id = 8, Author = "Ronty Pal", Name = "Life is a journey" },
                new BookModel() { Id = 9, Author = "Ankit Pal", Name = "Travel the world" }
            };
        }
    }
}
