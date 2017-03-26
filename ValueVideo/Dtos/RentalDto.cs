using System;

namespace ValueVideo.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public int CustomerId { get; set; }
        public MovieDto Movie { get; set; }
        public int MovieId { get; set; }
        public bool Returned { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}