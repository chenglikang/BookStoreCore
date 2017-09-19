using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookDetailsViewModel
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string Details { get; set; }
    }
}
