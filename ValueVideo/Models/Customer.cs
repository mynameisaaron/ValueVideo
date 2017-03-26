using System;
using System.ComponentModel.DataAnnotations;

namespace ValueVideo.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
    }

    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public short Fee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountPercentage { get; set; }
    }
}