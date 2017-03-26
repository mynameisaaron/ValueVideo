using System;

namespace ValueVideo.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public bool Returned { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime? ReturnDate { get; set; }

       
        
    }
}