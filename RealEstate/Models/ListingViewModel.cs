using System.ComponentModel.DataAnnotations;

namespace RealEstate.Models
{
    public class ListingViewModel
    {
        public IQueryable<Listing> Listings { get; set;}
        public string PriceSortOrder { get; set; }
        public string CitySortOrder { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string Term { get; set; }
        public string OrderBy { get; set; }
    }
}
