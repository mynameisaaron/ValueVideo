using System.Collections.Generic;
using ValueVideo.Models;

namespace ValueVideo.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}