using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AplicationDbContext:DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
        : base(options)
        { 
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        public DbSet<Villa> Villas {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "lorem",                          
                    Rate = 200,
                    Sqft = 500,
                    Occupancy = 4,
                    ImageUrl = " ",
                    Amenity = " ",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,

                },
                  new Villa
                  {
                      Id = 2,
                      Name = "Villa-Vip",
                      Details = "lorem",
                      Rate = 500,
                      Sqft = 700,
                      Occupancy = 6,
                      ImageUrl = " ",
                      Amenity = " ",
                      CreatedDate = DateTime.Now,
                      UpdatedDate = DateTime.Now,

                  },
                    new Villa
                    {
                        Id = 3,
                        Name = "Royal-Wild",
                        Details = "lorem",
                        Rate = 300,
                        Sqft = 500,
                        Occupancy = 4,
                        ImageUrl = " ",
                        Amenity = " ",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,

                    }



                );
        }

    }
}
