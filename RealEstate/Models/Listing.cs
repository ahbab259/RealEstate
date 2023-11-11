using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class Listing
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("House Number")]
        public string HouseNumber { get; set; }
        public string Road { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Price { get; set; }

    }
}
