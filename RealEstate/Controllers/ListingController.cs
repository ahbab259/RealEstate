using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            List<Listing> listings = new List<Listing>();
            listings = _db.Listings.ToList();
            return View(listings);
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
            if(lst == null)
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
    }
}
