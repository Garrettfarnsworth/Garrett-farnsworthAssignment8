using System;
using System.Linq;

namespace OnlineBooks.Models
{
    public class EFBookRespository : IBookRespository
    {
        private OnlineBookStoreDbContext _context;

        //Constructor for the repository.
        public EFBookRespository(OnlineBookStoreDbContext context)
        {
            _context = context;
        }
        //The => is for Lambda
        public IQueryable<Books> Books => _context.Books;
    }
}
