using System;

namespace ValueVideo.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }

    public class MembershipTypeDto
    {
        public byte Id { get; set; }
       public string Name { get; set; }
        public short Fee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountPercentage { get; set; }
    }
}