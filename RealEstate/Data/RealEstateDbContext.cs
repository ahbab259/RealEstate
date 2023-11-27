using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;

namespace RealEstate.Data
{
    public class RealEstateDbContext : IdentityDbContext
    {
        public RealEstateDbContext(DbContextOptions options): base(options) { }

        public DbSet<Listing> Listings { get; set; }

    }
}
