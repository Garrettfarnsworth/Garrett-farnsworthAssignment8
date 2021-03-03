using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineBooks.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required] //First name of the author
        public string FirstName { get; set; }

        [Required] // Last name of the author
        public string LastName { get; set; }

        [Required]
        public string Publisher { get; set; }


        [Required]
        //Validating the ISBN
        [RegularExpression(@"^\d{3}-{1}\d{10}$")]
        public string ISBN { get; set; }

        [Required] // Or classification
        public string Category { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Price { get; set; }
        [Required]
        public string PageNumber { get; set; }
    }
}
