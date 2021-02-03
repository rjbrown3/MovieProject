using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Models
{
    public static class MovieTempStorage
    {
        private static List<Movies> newMovies = new List<Movies>();

        public static IEnumerable<Movies> Movies => newMovies;

        public static void AddMovie(Movies movie)
        {
            if (!((movie.Rating is null) || (movie.Title is null) || (movie.Category is null) || (movie.Director is null) || (movie.Year == 0)))    
            //don't add movie to list if required fields are null (I know this isn't very efficient...)
            {
                newMovies.Add(movie);
            }
        }
    }
}
