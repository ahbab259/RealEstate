using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class ListingViewModel
    {
        public IQueryable<Listing> Listings { get; set;}
        public string PriceSortOrder { get; set; }
        public string CitySortOrder { get; set; }
    }
}
