using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)            //populate database with seed data
        {
            MovieDbContext context = application.ApplicationServices.CreateScope().
                ServiceProvider.GetRequiredService<MovieDbContext>();

            if (context.Database.GetPendingMigrations().Any())      //Make migrations when necessary
            {
                context.Database.Migrate();
            }

            if (!context.Movies.Any())
            {
                context.Movies.AddRange(

                    new Movies
                    {
                        Category = "Action",
                        Title = "Thor: Ragnarok",
                        Year = 2016,
                        Director = "Taika Waititi",
                        Rating = "PG",
                        Edited = false,
                        LentTo = "Ted",
                        Notes = "Avengers movie"
                    },

                    new Movies
                    {
                        Category = "Drama",
                        Title = "Bridge of Spies",
                        Year = 2015,
                        Director = "Steven Spielberg",
                        Rating = "PG-13",
                        Edited = false,
                        LentTo = "Mom",
                        Notes = "Tom Hanks plays the main character"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
