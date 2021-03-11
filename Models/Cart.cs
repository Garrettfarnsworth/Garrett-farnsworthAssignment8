using OnlineBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem (Books book, int qty)
        {
            CartLine Line = Lines
                //Looking out into the list to see if it is equal to the one in the Lines and if not we will go and add a new line.   
                .Where(p => p.Books.BookId == book.BookId)
                .FirstOrDefault();

            if (Line == null)
            {
                Lines.Add(new CartLine
                {
                    Books = book,
                    Quantity = qty
                });
            }
            //Otherwise we will update the quantity. 
            else
            {
                Line.Quantity += qty;
            }
        }
        //Code for removing a line object.
        public void RemoveLine(Books books) => 
            Lines.RemoveAll(x => x.Books.BookId == books.BookId);

        public void Clear() => Lines.Clear();

        //Calculation of the Total Sum
        public float ComputeTotalSum() => Lines.Sum(e => e.Books.Price * e.Quantity);
        

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Books Books { get; set; }
            public int Quantity { get; set; }
        }
    }
}
