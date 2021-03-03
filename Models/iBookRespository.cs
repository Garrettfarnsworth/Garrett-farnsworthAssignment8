using System;
using System.Linq;

namespace OnlineBooks.Models
{
    public interface IBookRespository
    {// The book repository that we are initializing
        IQueryable<Books> Books { get; }
    }
}
