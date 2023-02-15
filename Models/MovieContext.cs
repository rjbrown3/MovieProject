using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Models
{
    public class MovieContext : DbContext
    {
        //Constructor
        public MovieContext (DbContextOptions<MovieContext> options): base(options)
        {

        }

        public DbSet<Movies> movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movies>().HasData(
                
                new Movies
                {
                    MovieId = 1,
                    Category = "Thriller",
                    Title = "The Menu",
                    Year = 2022,
                    Director = "Mark Mylod",
                    Rating = "R",
                    Edited = false,
                    LentTo = "friend",
                    Notes = "Surprisingly hilarious"
                }
            );
        }
    }
}
