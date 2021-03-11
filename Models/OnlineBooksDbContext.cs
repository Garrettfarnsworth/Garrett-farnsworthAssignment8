using System;
using Microsoft.EntityFrameworkCore;

namespace OnlineBooks.Models
{
    //Inheriting from DbContext with the symbol ":" and CRUD is going on here!
    public class OnlineBookStoreDbContext : DbContext
    {
        //Constructor Inherits from the base
       public OnlineBookStoreDbContext (DbContextOptions<OnlineBookStoreDbContext> options) : base (options)
        {

        }

        //Returns a set of Book ojects
        public DbSet<Books> Books { get; set; }
    }
}
