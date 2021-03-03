using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OnlineBooks.Models
{//This is what initially seeds the database, but once migrated isn't necessarily needed anymore. One the database is created,
    //Our program will just pull from that! 
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            OnlineBookStoreDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<OnlineBookStoreDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if(!context.Books.Any())
            {
                context.Books.AddRange(

                    new Books
                    { // First name and last name for all refer to the author.
                        Title = "Les Miserables",
                        FirstName = "Victor",
                        LastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Category = "Fiction",
                        Genre = "Classic",
                        Price = "$9.95",
                        PageNumber = "1488"
                    },

                    new Books
                    {
                        Title = "Team of Rivals",
                        FirstName = "Doris Kearns",
                        LastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Category = "Non-Fiction",
                        Genre = "Biography",
                        Price = "$14.58",
                        PageNumber = "944"
                    },

                    new Books
                    {
                        Title = "The Snowball",
                        FirstName = "Alice",
                        LastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0451419439",
                        Category = "Non-Fiction",
                        Genre = "Biography",
                        Price = "$21.54",
                        PageNumber = "832"
                    },

                    new Books
                    {
                        Title = "American Ulysses",
                        FirstName = "Ronald C.",
                        LastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254 ",
                        Category = "Non-Fiction",
                        Genre = "Biography",
                        Price = "$11.61",
                        PageNumber = "864"
                    },

                    new Books
                    {
                        Title = "Unbroken",
                        FirstName = "Laura",
                        LastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Category = "Non-Fiction",
                        Genre = "Historical",
                        Price = "$13.33",
                        PageNumber = "528"
                    },

                    new Books
                    {
                        Title = "The Great Train Robbery",
                        FirstName = "Michael",
                        LastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Category = "Fiction",
                        Genre = "Historical Fiction",
                        Price = "$15.95",
                        PageNumber = "288"
                    },

                    new Books
                    {
                        Title = "Deep Work",
                        FirstName = "CaL",
                        LastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Category = "Non-Fiction",
                        Genre = "Self-Help",
                        Price = "$14.99",
                        PageNumber = "304"
                    },

                    new Books
                    {
                        Title = "It's Your Ship",
                        FirstName = "Michael",
                        LastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Category = "Non-Fiction",
                        Genre = "Self-Help",
                        Price = "$21.66",
                        PageNumber = "240"
                    },

                    new Books
                    {
                        Title = "The Virgin Way",
                        FirstName = "Richard",
                        LastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Category = "Non-Fiction",
                        Genre = "Business",
                        Price = "$29.16",
                        PageNumber = "400"
                    },

                    new Books
                    {
                        Title = "Sycamore Row",
                        FirstName = "John",
                        LastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Category = "Fiction",
                        Genre = "Thrillers",
                        Price = "$15.03",
                        PageNumber = "642"
                    },

                    new Books
                    {
                        Title = "How to win friends and influce people",
                        FirstName = "Dale",
                        LastName = "Carnegie",
                        Publisher = "Simon & Schuster (1936)",
                        ISBN = "978-0671027032",
                        Category = "Self-help book",
                        Genre = "Self-help book",
                        Price = "$12.99",
                        PageNumber = "291"
                    },

                    new Books
                    {
                        Title = "The Giver",
                        FirstName = "Lois",
                        LastName = "Lowry",
                        Publisher = "Houghton Mifflin Harcourt",
                        ISBN = "978-385732550",
                        Category = "Young Adult Fiction",
                        Genre = "Science Fiction",
                        Price = "$9.99",
                        PageNumber = "192"
                    },

                    new Books
                    {
                        Title = "Left to tell",
                        FirstName = " Immaculée",
                        LastName = "Ilibagiza",
                        Publisher = "Hay House Inc",
                        ISBN = "978-1401944322",
                        Category = "Non-Fiction",
                        Genre = "Biography",
                        Price = "$9.99",
                        PageNumber = "256"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
