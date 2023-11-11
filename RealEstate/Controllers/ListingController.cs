using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    public class ListingController : Controller
    {
        private readonly RealEstateDbContext _db;
        public ListingController(RealEstateDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string? term, string? orderBy, int currentpage = 1)
        {
            term = string.IsNullOrEmpty(term) ? "" : term.ToLower();

            var listingData = new ListingViewModel();
            listingData.PriceSortOrder = string.IsNullOrEmpty(orderBy) ? "price_desc" : "";
            listingData.CitySortOrder = string.IsNullOrEmpty(orderBy) ? "city_desc" : "";


            var listings = (from lst in _db.Listings
                            where term == "" || lst.City.ToLower().Contains(term)
                            select new Listing
                            {
                                Id = lst.Id,
                                City = lst.City,
                                Country = lst.Country,
                                HouseNumber = lst.HouseNumber,
                                Price = lst.Price,
                                Road = lst.Road,
                                State = lst.State,
                                ZIP = lst.ZIP
                            });
            switch (orderBy)
            {
                case "price_desc":
                    listings = listings.OrderBy(x => x.Price);
                    break;

                case "city_desc":
                    listings = listings.OrderBy(x => x.City);
                    break;

                default: break;
            }
            int totalRecords = listings.Count();
            int pageSize = 5;
            int totalPages = (int)Math.Ceiling((decimal)totalRecords/pageSize);

            listings = listings.Skip((currentpage - 1) * pageSize).Take(pageSize);


            listingData.Listings = listings;

            listingData.CurrentPage = currentpage;
            listingData.PageSize = pageSize;
            listingData.TotalPages = totalPages;
            listingData.Term = term;
            listingData.OrderBy = orderBy;

            return View(listingData);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Listing obj)
        {
            if (ModelState.IsValid)
            {
                _db.Listings.Add(obj);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Edit(Guid Id)
        {
            Listing? lst = _db.Listings.Find(Id);
            if (lst == null)
            {
                return NotFound();
            }
            else return View(lst);
        }
        [HttpPost]
        public IActionResult Edit(Listing obj)
        {
            if (ModelState.IsValid)
            {
                _db.Listings.Update(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Details(Guid Id)
        {
            Listing? lst = _db.Listings.Find(Id);
            if (lst == null)
            {
                return NotFound();
            }
            else return View(lst);
        }
        public IActionResult Delete(Guid Id)
        {
            Listing? lst = _db.Listings.Find(Id);
            if (lst == null)
            {
                return NotFound();
            }
            else
            {
                _db.Remove(lst);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
