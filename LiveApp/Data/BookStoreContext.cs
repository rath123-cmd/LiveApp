using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveApp.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
    }
}
