using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class ListingViewModel
    {
        public IQueryable<Listing> Listings { get; set;}
    }
}
