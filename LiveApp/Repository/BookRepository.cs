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
                new BookModel() { Id = 1, Author = "Rathin Karmakar", Name = "How to live a life", Category = "Action", Description = "How to live a lifeHow to live a lifeHow to live a lifeHow to live a lifeHow to live a lifeHow to live a lifeHow to live a lifeHow to live a lifeHow to live a life", Language = "English", TotalPages = 1023 },
                new BookModel() { Id = 2, Author = "Tapendu Karmakar", Name = "Sea of life", Category = "Adventure", Description = "Sea of lifeSea of lifeSea of lifeSea of lifeSea of lifeSea of lifeSea of lifeSea of life", Language = "Bengali", TotalPages = 1232 },
                new BookModel() { Id = 3, Author = "Rathin Das", Name = "How to draw", Category = "Romance", Description = "How to drawHow to drawHow to drawHow to drawHow to drawHow to drawHow to drawHow to draw", Language = "Hindi", TotalPages = 104343 },
                new BookModel() { Id = 4, Author = "Subendu Mondal", Name = "What is life", Category = "Progeramming", Description = "What is lifeWhat is lifeWhat is lifeWhat is lifeWhat is lifeWhat is lifeWhat is lifeWhat is life", Language = "Bengali", TotalPages = 3643 },
                new BookModel() { Id = 5, Author = "Smriti Das", Name = "Life is short", Category = "Devops", Description = "Life is shortLife is shortLife is shortLife is shortLife is shortLife is shortLife is shortLife is shortLife is shortLife is shortLife is short", Language = "English", TotalPages = 6575 },
                new BookModel() { Id = 6, Author = "Suman Karmakar", Name = "Live yourself", Category = "Travel", Description = "Live yourselfLive yourselfLive yourselfLive yourselfLive yourselfLive yourselfLive yourselfLive yourselfLive yourselfLive yourselfLive yourselfLive yourselfLive yourself", Language = "Hindi", TotalPages = 57547 },
                new BookModel() { Id = 7, Author = "Rathin Bhattacharya", Name = "Dont give up", Category = "Romance", Description = "Dont give upDont give upDont give upDont give upDont give upDont give upDont give upDont give upDont give upDont give up", Language = "English", TotalPages = 5756 },
                new BookModel() { Id = 8, Author = "Ronty Pal", Name = "Life is a journey", Category = "Adventure", Description = "Life is a journeyLife is a journeyLife is a journeyLife is a journeyLife is a journeyLife is a journeyLife is a journeyLife is a journeyLife is a journey", Language = "Bengali", TotalPages = 342 },
                new BookModel() { Id = 9, Author = "Ankit Pal", Name = "Travel the world", Category = "Action", Description = "Travel the worldTravel the worldTravel the worldTravel the worldTravel the worldTravel the worldTravel the worldTravel the worldTravel the worldTravel the worldTravel the worldTravel the worldTravel the world", Language = "English", TotalPages = 76757 }
            };
        }
    }
}
